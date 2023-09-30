namespace Auboreal {

	using UnityEngine;

	public class MicroGameFlowManager : MonoBehaviour {

		private AMicroGameController m_CurrentMicroGameController;


		#region Unity Methods

		private void Start() {
			StartRandomMicroGame();
		}

		#endregion


		private void StartRandomMicroGame() {
			var randomMicroGame = GetRandomMicroGame();
			m_CurrentMicroGameController = MicroGameFactory.CreateMicroGameController(randomMicroGame);
		}


		private void EndCurrentMicroGame() {
			m_CurrentMicroGameController?.EndMicroGame();
		}

		private PersistentData.MicroGame GetRandomMicroGame() {
			var microGames = PersistentData.instance.microgames;
			var microGameIndex = Random.Range(0, microGames.Length);
			// TODO(Ayoub): revert this back to random
			return microGames[0];
		}

	}

}