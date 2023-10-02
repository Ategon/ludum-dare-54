namespace Auboreal {

	public class OrbitMicroGameController : AMicroGameController {
		public Satellite sat;

		protected override void OnGameStarted() {
			base.OnGameStarted();
			sat.OnGameStarted();
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
		}

	}

}