namespace Auboreal {

	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class SceneManagerWrapper {

		private PersistentData.MicroGame m_CurrentMicroGame;

		public void SwitchScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode) {
			if (m_CurrentMicroGame != null) {
				var unloadOp = SceneManager.UnloadSceneAsync(m_CurrentMicroGame.sceneName);
				unloadOp.completed += (op) => LoadNewScene(microGame, loadSceneMode);
			}
			else {
				LoadNewScene(microGame, loadSceneMode);
			}
		}

		private void LoadNewScene(PersistentData.MicroGame microGame, LoadSceneMode loadSceneMode) {
			if (microGame == null) {
				Debug.LogError("MicroGame is null in LoadNewScene.");
				return;
			}

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
	}
}