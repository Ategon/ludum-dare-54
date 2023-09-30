namespace Auboreal {

	public class WaitMicroGameController : AMicroGameController {

		protected override void OnGameStarted() {
			base.OnGameStarted();
			RegisterEvents();
		}

		protected override void OnGameEnded() {
			UnRegisterEvents();
			base.OnGameEnded();
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