namespace Auboreal {

	using UnityEngine;

	public class MainMenu : MonoBehaviour {

		public void StartGame() {
			
			FindObjectOfType<MicroGameFlowManager>()
				.StartMicroGame(PersistentData.Instance.GetRandomMicroGame(), isComingFromMenu: true);
		}

	}

}