using UnityEngine;

namespace Auboreal {

	public class WaitMicroGameController : AMicroGameController {
		public GameObject coffee;
		public GameObject explosion;

		public float timer;

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
			if (!ended)
            {
				GameObject summonedExplosion3 = Instantiate(explosion, coffee.transform.position, coffee.transform.rotation);
				summonedExplosion3.transform.SetParent(transform.parent);

				OnFailure();

				Destroy(coffee);
			}
		}

		private void FixedUpdate()
        {
			timer += Time.deltaTime;

			if (timer >= 2)
            {
				OnSuccess();
			}
        }
	}

}