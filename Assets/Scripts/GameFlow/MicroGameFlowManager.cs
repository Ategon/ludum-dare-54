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
			ActionEventSystem.OnMicroGameLoaded += StartMicroGame;
		}
		
		private void OnDisable() {
			ActionEventSystem.OnMicroGameLoaded -= StartMicroGame;
		}

		public void StartMicroGame(PersistentData.MicroGame newMicroGame) {
			PersistentData.instance.SwitchScene(newMicroGame, LoadSceneMode.Additive);
		}

		private void EndCurrentMicroGame() { }

		private PersistentData.MicroGame GetRandomMicroGame() {
			var microGames = PersistentData.instance.microgames;
			var microGameIndex = Random.Range(0, microGames.Length);
			// TODO(Ayoub): revert this back to random
			return microGames[0];
		}

	}

}