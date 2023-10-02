using UnityEngine;
using DG.Tweening;

namespace Auboreal {

	public class JumpMicroGameController : AMicroGameController {
		public float position;
		public Transform safebar1;
		public Transform safebar2;
		public JumpIndicator indicator;
		public GameObject ship;
		public GameObject explosion;
		public ConstantMovement mov;

		protected override void OnGameStarted() {
			lost = true;
			position = Random.Range(-0.4f, 0.4f);
			safebar1.position = new Vector3(position - 0.07f, safebar1.position.y, safebar1.position.z);
			safebar2.position = new Vector3(position + 0.07f, safebar2.position.y, safebar2.position.z);
			base.OnGameStarted();
			RegisterEvents();
		}

		protected override void OnGameEnded() {
			base.OnGameEnded();
			UnRegisterEvents();
		}

		private void RegisterEvents()
		{
			EventManager.Input.OnAnyInputPressed += OnAnyInputPressed;
		}

		private void UnRegisterEvents()
		{
			EventManager.Input.OnAnyInputPressed -= OnAnyInputPressed;
		}

		private void OnAnyInputPressed()
		{
			if (!indicator.moving) return;

			indicator.moving = false;

			if (indicator.transform.position.x >= safebar1.position.x && indicator.transform.position.x <= safebar2.position.x)
            {
				lost = false;
				DOTween.To(() => mov.speed, x => mov.speed = x, 1.5f, 1.0f);
				DOTween.To(() => mov.speed, x => mov.speed = x, 0.1f, 1.0f).SetDelay(1.5f);
				ship.transform.DOLocalMoveX(2, 1f).SetEase(Ease.InBack);
			} else
            {
				GameObject summonedExplosion = Instantiate(explosion, ship.transform.position, ship.transform.rotation);
				summonedExplosion.transform.SetParent(transform.parent);
				Destroy(ship);
            }
		}
	}

}