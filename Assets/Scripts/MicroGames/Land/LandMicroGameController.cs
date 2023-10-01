namespace Auboreal {

	public class LandMicroGameController : AMicroGameController {
		
		public LandSpaceship landSpaceship;
		
		protected override void OnGameStarted() {
			base.OnGameStarted();
			landSpaceship.OnGameStarted();
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
		}

	}

}