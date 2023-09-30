namespace Auboreal {

	public class WaitMicroGameController : AMicroGameController {

		protected override void OnGameStarted() {
			base.OnGameEnded();
			RegisterEvents();
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
			UnRegisterEvents();
		}

		private void RegisterEvents() {
			EventManager.Input.OnAnyInputPressed += OnAnyInputPressed;
		}
		
		private void UnRegisterEvents() {
			EventManager.Input.OnAnyInputPressed -= OnAnyInputPressed;
		}

		private void OnAnyInputPressed() {
			EndMicroGame();
		}

	}

}