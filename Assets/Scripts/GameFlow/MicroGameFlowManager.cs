namespace Auboreal {

	using UnityEngine.SceneManagement;
	using UnityEngine;

	public class MicroGameFlowManager : MonoBehaviour {

		private void Start() {
			StartMicroGame(PersistentData.Instance.GetRandomMicroGame());
		}
		
		private void OnEnable() {
			EventManager.GameFlow.OnGameEnded += EndCurrentMicroGame;
			EventManager.Debug.OnMicroGameSelected += StartMicroGame;
		}

		private void OnDisable() {
			EventManager.GameFlow.OnGameEnded -= EndCurrentMicroGame;
			EventManager.Debug.OnMicroGameSelected -= StartMicroGame;
		}

		public void StartMicroGame(PersistentData.MicroGame newMicroGame) {
			PersistentData.Instance.SwitchScene(newMicroGame, LoadSceneMode.Additive);
		}

		private void EndCurrentMicroGame(PersistentData.MicroGame microgame) {
			Debug.Log("END");
			StartMicroGame(PersistentData.Instance.GetRandomMicroGame());
		}

	}

}