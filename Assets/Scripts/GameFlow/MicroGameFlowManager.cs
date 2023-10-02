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

		public void StartMicroGame(PersistentData.MicroGame newMicroGame, bool isComingFromMenu) {
			Debug.Log("StartMicroGame");
			if (isComingFromMenu)
			{
				PersistentData.Instance.Health = 3;
				PersistentData.Instance.Score = 0;
			}
			EventManager.Global.MicroGameSceneSwitch(newMicroGame);
			PersistentData.Instance.SwitchScene(newMicroGame, LoadSceneMode.Additive, isComingFromMenu);
		}

		private void OnRequestMicroGame() {
			Debug.Log("OnRequestMicroGame");
			StartMicroGame(PersistentData.Instance.GetRandomMicroGame(), false);
		}

	}

}