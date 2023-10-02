using System;
using System.Collections;

namespace Auboreal {

	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class SceneManagerWrapper {

		private const string MainMenuScene = "MainMenu";
		private const string IntermediateScene = "_Intermediate";

		private bool m_IsSwitching = false;
		private readonly float m_TranistionSceneDuration;
		private PersistentData.MicroGame m_CurrentMicroGame;

		public SceneManagerWrapper(float transitionDuration) {
			m_TranistionSceneDuration = transitionDuration;
		}

		public void SwitchScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode,
			bool isComingFromMenu) {
			if (m_IsSwitching) {
				Debug.LogWarning("Scene switch already in progress. Ignoring request.");
				return;
			}

			if (microGame == null) {
				Debug.LogError("Micro Game passed to switch scene is null");
				return;
			}

			m_IsSwitching = true;

			LoadIntermediateScene(microGame, loadSceneMode, isComingFromMenu);
		}

		private void LoadIntermediateScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode,
			bool isComingFromMenu) {
			if (!IsSceneLoaded(IntermediateScene)) {
				var loadInter = SceneManager.LoadSceneAsync(IntermediateScene, loadSceneMode);

				loadInter.completed += (op) => {
					CoroutineHelper.Instance.StartCoroutine(WaitInIntermediate(() => {
						// After the delay, unload the appropriate scene and proceed to the next micro game.
						UnloadPreviousScene(isComingFromMenu, () => { LoadNewScene(microGame, loadSceneMode); });
					}));
				};
			}
			else {
				CoroutineHelper.Instance.StartCoroutine(WaitInIntermediate(() => {
					UnloadPreviousScene(isComingFromMenu, () => { LoadNewScene(microGame, loadSceneMode); });
				}));
			}
		}

		private IEnumerator WaitInIntermediate(System.Action onComplete) {
			yield return new WaitForSeconds(m_TranistionSceneDuration);
			onComplete();
		}

		private void UnloadPreviousScene(bool isComingFromMenu, System.Action onComplete) {
			string sceneToUnload = isComingFromMenu ? MainMenuScene : m_CurrentMicroGame.sceneName;

			if (IsSceneLoaded(sceneToUnload)) {
				var unloadOp = SceneManager.UnloadSceneAsync(sceneToUnload);
				unloadOp.completed += (_) => onComplete();
			}
			else {
				onComplete();
			}
		}

		private void LoadNewScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode) {
			m_CurrentMicroGame = microGame;
			SceneManager.sceneLoaded += OnMicroGameSceneLoaded;
			SceneManager.LoadSceneAsync(microGame.sceneName, loadSceneMode);
		}

		private void OnMicroGameSceneLoaded(Scene microGameScene, LoadSceneMode sceneMode) {
			SceneManager.sceneLoaded -= OnMicroGameSceneLoaded;

			// Unload intermediate scene after the new scene has been loaded
			if (IsSceneLoaded(IntermediateScene)) {
				SceneManager.UnloadSceneAsync(IntermediateScene);
			}

			var controller = Object.FindObjectOfType<AMicroGameController>();

			if (controller != null) {
				controller.Initialize(m_CurrentMicroGame);
			}
			else {
				Debug.LogError($"No MicroGameController found in scene: {microGameScene.name}");
			}

			m_IsSwitching = false; // Release the lock
		}

		private bool IsSceneLoaded(string sceneName) {
			return SceneManager.GetSceneByName(sceneName).isLoaded;
		}

	}

}