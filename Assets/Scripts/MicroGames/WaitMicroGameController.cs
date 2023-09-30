namespace Auboreal {

	using UnityEngine;

	public class WaitMicroGameController : AMicroGameController {

		public WaitMicroGameController(PersistentData.MicroGame microGameInstance)
			: base(microGameInstance) { }

		protected override void OnGameStarted() { }

		protected override void OnGameEnded() { }

	}

}