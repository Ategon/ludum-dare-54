namespace Auboreal {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Auboreal;

	public class MainMenu : MonoBehaviour {
		private bool started = false;

		public void StartGame() {
			if (started) return;
			started = true;
			FindObjectOfType<MicroGameFlowManager>()
				.StartMicroGame(PersistentData.Instance.GetRandomMicroGame(), isComingFromMenu: true);
		}

		public void QuitGame()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

		public void Leaderboard() { }

		public void Credits() { }

		public void Options() { }

	}

}