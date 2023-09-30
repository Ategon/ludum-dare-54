namespace Auboreal {

	using UnityEngine.SceneManagement;
	using UnityEngine;

	public class MicroGameFlowManager : MonoBehaviour {

		#region Unity Methods

		// private void Start() {
		// 	var randomMicroGame = GetRandomMicroGame();
		// 	StartMicroGame(randomMicroGame);
		// }

		#endregion


		private void OnEnable() {
			EventManager.OnMicroGameSelected += StartMicroGame;
		}

		private void OnDisable() {
			EventManager.OnMicroGameSelected -= StartMicroGame;
		}

		public void StartMicroGame(PersistentData.MicroGame newMicroGame) {
			PersistentData.Instance.SwitchScene(newMicroGame, LoadSceneMode.Additive);
		}

		private void EndCurrentMicroGame() { }

	}

}