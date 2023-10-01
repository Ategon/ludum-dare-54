namespace Auboreal {

	using UnityEngine.SceneManagement;
	using UnityEngine;

	public class MicroGameFlowManager : MonoBehaviour {

		/// <summary>
		/// Entry point
		/// </summary>
		private void Start() {
			StartMicroGame(PersistentData.Instance.GetRandomMicroGame());
		}

		public void StartMicroGame(PersistentData.MicroGame newMicroGame) {
			PersistentData.Instance.SwitchScene(newMicroGame, LoadSceneMode.Additive);
		}

		private void OnEnable() {
			EventManager.Global.OnRequestNextMicroGame += OnRequestMicroGame;
			EventManager.Debug.OnMicroGameSelected += StartMicroGame;
		}

		private void OnDisable() {
			EventManager.Global.OnRequestNextMicroGame -= OnRequestMicroGame;
			EventManager.Debug.OnMicroGameSelected -= StartMicroGame;
		}


		private void OnRequestMicroGame() {
			StartMicroGame(PersistentData.Instance.GetRandomMicroGame());
		}

	}

}