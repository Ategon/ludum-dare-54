namespace Auboreal {

	public class ShootMicroGameController : AMicroGameController {

		public ShootSpaceShip shootSpaceShip;
		public ShootDeadZone shootDeadZone;
		
		protected override void OnGameStarted() {
			base.OnGameStarted();
			shootDeadZone.OnGameStarted(this);
			shootSpaceShip.OnGameStarted(this);
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
		}

	}

}