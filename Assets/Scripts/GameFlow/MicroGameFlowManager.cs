namespace Auboreal {

	using UnityEngine.SceneManagement;
	using UnityEngine;

	public class MicroGameFlowManager : MonoBehaviour {
		private void OnEnable() {
			EventManager.Global.OnRequestNextMicroGame += OnRequestMicroGame;
		}

		private void OnDisable() {
			EventManager.Global.OnRequestNextMicroGame -= OnRequestMicroGame;
		}

		public void StartMicroGame(PersistentData.MicroGame newMicroGame) {
			Debug.Log("StartMicroGame");
			PersistentData.Instance.SwitchScene(newMicroGame, LoadSceneMode.Additive);
		}

		private void OnRequestMicroGame() {
			Debug.Log("OnRequestMicroGame");
			StartMicroGame(PersistentData.Instance.GetRandomMicroGame());
		}

	}

}