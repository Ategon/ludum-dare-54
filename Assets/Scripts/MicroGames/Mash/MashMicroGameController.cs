namespace Auboreal {

	public class MashMicroGameController : AMicroGameController {

		public MashSpaceship mashSpaceship;

		protected override void OnGameStarted() {
			RegisterEvents();
			base.OnGameStarted();
			mashSpaceship.OnStart(this);
		}

		protected override void OnGameEnded() {
			UnRegisterEvents();
			base.OnGameEnded();
			mashSpaceship.OnEnd();
		}

		private void RegisterEvents() {
			EventManager.Input.OnAnyInputPressed += OnAnyInputPressed;
		}

		private void UnRegisterEvents() {
			EventManager.Input.OnAnyInputPressed -= OnAnyInputPressed;
		}

		private void OnAnyInputPressed() {
			mashSpaceship.Move();
		}

	}

}