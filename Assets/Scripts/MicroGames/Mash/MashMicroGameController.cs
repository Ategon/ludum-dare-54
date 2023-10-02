using UnityEngine;

namespace Auboreal {

	public class MashMicroGameController : AMicroGameController {

		private MashSpaceship mashSpaceship;

        private void Awake()
        {
			mashSpaceship = FindObjectOfType<MashSpaceship>();
        }

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
			mashSpaceship.Move();
		}


	}

}