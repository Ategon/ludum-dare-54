namespace Auboreal {

	public class LandMicroGameController : AMicroGameController {

		public LandSpaceship landSpaceship;
		public LandPlatformLocator landPlatformLocator;

		protected override void OnGameStarted() {
			lost = true;
			base.OnGameStarted();
			landPlatformLocator.OnStart(this);
			landSpaceship.OnStart(this);
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
			landPlatformLocator.OnEnd();
			landSpaceship.OnEnd();
		}

		public void EndGame(bool lost = false) {
			EndMicroGame(this.MicroGameInstance);
		}

	}

}