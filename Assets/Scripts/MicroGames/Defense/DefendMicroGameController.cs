namespace Auboreal {

	public class DefendMicroGameController : AMicroGameController {

		protected override void OnGameStarted() {
			base.OnGameStarted();
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
		}

		public void EndGame(bool lost)
        {
			EndMicroGame(this.MicroGameInstance, lost);
		}

	}

}