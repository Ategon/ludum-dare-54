namespace Auboreal {

	public class DefendMicroGameController : AMicroGameController {

		public Planet planet;

		protected override void OnGameStarted() {
			base.OnGameStarted();
			planet.OnStart(this);
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
			planet.OnEnd();
		}

	}

}