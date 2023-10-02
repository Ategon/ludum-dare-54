using UnityEngine;

namespace Auboreal {

	public class WaitMicroGameController : AMicroGameController {
		public GameObject coffee;
		public GameObject explosion;

		protected override void OnGameStarted() {
			RegisterEvents();
			base.OnGameStarted();
		}

		protected override void OnGameEnded() {
			UnRegisterEvents();
			base.OnGameEnded();
		}

		private void RegisterEvents() {
			EventManager.Input.OnAnyInputPressed += OnAnyInputPressed;
		}
		
		private void UnRegisterEvents() {
			EventManager.Input.OnAnyInputPressed -= OnAnyInputPressed;
		}

		private void OnAnyInputPressed() {
			if (!lost)
            {
				lost = true;

				GameObject summonedExplosion3 = Instantiate(explosion, coffee.transform.position, coffee.transform.rotation);
				summonedExplosion3.transform.SetParent(transform.parent);

				Destroy(coffee);
			}
		}

	}

}