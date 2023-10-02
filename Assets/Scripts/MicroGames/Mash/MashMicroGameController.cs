using UnityEngine;

namespace Auboreal {

	public class MashMicroGameController : AMicroGameController {

		public int check = 0;
		protected override void OnGameStarted()
		{
			RegisterEvents();
			base.OnGameStarted();
		}

		protected override void OnGameEnded()
		{
			UnRegisterEvents();
			base.OnGameEnded();
		}

		private void RegisterEvents()
		{
			EventManager.Input.OnAnyInputPressed += OnAnyInputPressed;
		}

		private void UnRegisterEvents()
		{
			EventManager.Input.OnAnyInputPressed -= OnAnyInputPressed;
		}

		private void OnAnyInputPressed()
		{
			check = 1;
			Debug.Log("OnAnyInputPressed");
		}


	}

}