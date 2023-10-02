namespace Auboreal {

	public class RepairMicroGameController : AMicroGameController {

		public RepairSpaceShip repairSpaceShip;

		protected override void OnGameStarted() {
			lost = true;
			base.OnGameStarted();
			repairSpaceShip.OnGameStarted();
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
		}

	}

}