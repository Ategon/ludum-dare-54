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

		public void StartMicroGame(PersistentData.MicroGame newMicroGame, bool isComingFromMenu, bool isComingFromRestart = false) {
			if (isComingFromMenu || isComingFromRestart)
			{
				PersistentData.Instance.Health = 3;
				PersistentData.Instance.Score = 0;
			}
			
			if (!isComingFromRestart)
			{
				EventManager.Global.MicroGameSceneSwitch(newMicroGame);
				PersistentData.Instance.SwitchScene(newMicroGame, LoadSceneMode.Additive, isComingFromMenu);
			}
		}

		private void OnRequestMicroGame() {
			StartMicroGame(PersistentData.Instance.GetRandomMicroGame(), false);
		}

	}

}