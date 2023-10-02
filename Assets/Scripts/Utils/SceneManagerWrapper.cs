namespace Auboreal {

	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class SceneManagerWrapper {

		private const string MainMenuScene = "MainMenu";
		private const string IntermediateScene = "_Intermediate";

		private PersistentData.MicroGame m_CurrentMicroGame;

		public void SwitchScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode,
			bool isComingFromMenu) {
			if (microGame == null) {
				Debug.LogError("Micro Game passed to switch scene is null");
				return;
			}

			if (isComingFromMenu && !IsSceneLoaded(IntermediateScene)) {
				var loadInter = SceneManager.LoadSceneAsync(IntermediateScene, loadSceneMode);

				loadInter.completed += (_) => {
					if (IsSceneLoaded(MainMenuScene)) {
						var unloadOp = SceneManager.UnloadSceneAsync(MainMenuScene);
						unloadOp.completed += (op) => LoadIntermediateScene(microGame, loadSceneMode);
					}
					else {
						LoadIntermediateScene(microGame, loadSceneMode);
					}
				};
			}
			else {
				var unloadOp = SceneManager.UnloadSceneAsync(m_CurrentMicroGame.sceneName);
				unloadOp.completed += (op) => LoadIntermediateScene(microGame, loadSceneMode);
			}
		}

		private void LoadIntermediateScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode) {
			var loadInter = SceneManager.LoadSceneAsync(IntermediateScene, loadSceneMode);

			loadInter.completed += (op) => {
				var unloadOp = SceneManager.UnloadSceneAsync(IntermediateScene);
				unloadOp.completed += (unloadOp) => LoadNewScene(microGame, loadSceneMode);
			};
		}

		private void LoadNewScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode) {
			m_CurrentMicroGame = microGame;
			SceneManager.sceneLoaded += OnMicroGameSceneLoaded;
			SceneManager.LoadSceneAsync(microGame.sceneName, loadSceneMode);
		}

		private void OnMicroGameSceneLoaded(Scene microGameScene, LoadSceneMode sceneMode) {
			SceneManager.sceneLoaded -= OnMicroGameSceneLoaded;

			var controller = Object.FindObjectOfType<AMicroGameController>();

			if (controller != null) {
				controller.Initialize(m_CurrentMicroGame);
			}
			else {
				Debug.LogError($"No MicroGameController found in scene: {microGameScene.name}");
			}
		}

		private bool IsSceneLoaded(string sceneName) {
			return SceneManager.GetSceneByName(sceneName).isLoaded;
		}

	}

}