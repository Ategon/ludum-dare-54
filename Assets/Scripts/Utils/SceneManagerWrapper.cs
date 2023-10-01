namespace Auboreal {

	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class SceneManagerWrapper {

		private PersistentData.MicroGame m_CurrentMicroGame;

		public void SwitchScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode) {
			if (microGame == null) {
				Debug.LogError("Micro Game passed to switch scene is null");
			}

			if (m_CurrentMicroGame != null) {
				var unloadOp = SceneManager.UnloadSceneAsync(m_CurrentMicroGame.sceneName);
				unloadOp.completed += (op) => LoadIntermediateScene(microGame, loadSceneMode);
			}
			else {
				LoadIntermediateScene(microGame, loadSceneMode);
			}
		}

		private void LoadIntermediateScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode) {
			var loadInter = SceneManager.LoadSceneAsync("_Intermediate", loadSceneMode);
			loadInter.completed += (op) => LoadNewScene(microGame, loadSceneMode);
		}

		private void LoadNewScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode) {
			var unloadOp = SceneManager.UnloadSceneAsync("_Intermediate");

			unloadOp.completed += (op) => {
				if (microGame == null) {
					Debug.LogError("MicroGame is null in LoadNewScene.");
					return;
				}

				m_CurrentMicroGame = microGame;
				SceneManager.sceneLoaded += OnMicroGameSceneLoaded;
				SceneManager.LoadSceneAsync(microGame.sceneName, loadSceneMode);
			};
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

	}

}