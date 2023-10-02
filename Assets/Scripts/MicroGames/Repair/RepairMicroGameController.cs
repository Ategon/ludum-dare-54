namespace Auboreal {

	public class RepairMicroGameController : AMicroGameController {

		public RepairSpaceShip repairSpaceShip;

		protected override void OnGameStarted() {
			base.OnGameStarted();
			repairSpaceShip.OnGameStarted();
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
		}

	}

}