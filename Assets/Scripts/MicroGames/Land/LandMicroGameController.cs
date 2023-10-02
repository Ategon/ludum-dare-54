namespace Auboreal {

	public class LandMicroGameController : AMicroGameController {

		public LandSpaceship landSpaceship;
		public LandPlatformLocator landPlatformLocator;

		protected override void OnGameStarted() {
			lost = true;
			base.OnGameStarted();
			landPlatformLocator.OnGameStarted();
			landSpaceship.OnGameStarted();
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
		}

		public void EndGame(bool lost = false)
		{
			EndMicroGame(this.MicroGameInstance);
		}

	}

}