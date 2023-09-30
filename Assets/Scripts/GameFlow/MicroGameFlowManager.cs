namespace Auboreal {

	using UnityEngine.SceneManagement;
	using UnityEngine;

	public class MicroGameFlowManager : MonoBehaviour {

		private void OnEnable() {
			EventManager.Debug.OnMicroGameSelected += StartMicroGame;
		}

		private void OnDisable() {
			EventManager.Debug.OnMicroGameSelected -= StartMicroGame;
		}

		public void StartMicroGame(PersistentData.MicroGame newMicroGame) {
			PersistentData.Instance.SwitchScene(newMicroGame, LoadSceneMode.Additive);
		}

		private void EndCurrentMicroGame() { }

	}

}