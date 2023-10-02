namespace Auboreal {

	public class ShootMicroGameController : AMicroGameController {

		public ShootSpaceShip shootSpaceShip;
		
		protected override void OnGameStarted() {
			base.OnGameStarted();
			shootSpaceShip.OnGameStarted(this);
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
		}

	}

}