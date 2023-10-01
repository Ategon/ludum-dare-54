namespace Auboreal {

	public class LandMicroGameController : AMicroGameController {

		public LandSpaceship landSpaceship;
		public LandPlatformLocator landPlatformLocator;

		protected override void OnGameStarted() {
			base.OnGameStarted();
			landPlatformLocator.OnGameStarted();
			landSpaceship.OnGameStarted();
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
		}

	}

}