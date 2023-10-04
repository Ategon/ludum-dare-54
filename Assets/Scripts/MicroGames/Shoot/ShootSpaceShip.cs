namespace Auboreal {

	using System;
	using DG.Tweening;
	using UnityEngine;

	public class ShootSpaceShip : MonoBehaviour {

		[SerializeField] private GameObject explosion;

		public float spaceShipSpeed;
		public float spaceShipThurst;
		public Camera mainCamera;
		public SpriteRenderer spaceShipRenderer;

		[Header("Shooting")]
		public Transform bulletSpawnTransform;
		public Transform bulletSpawnTransform2;

		public Transform bulletsContainer;
		public ShootBullet bulletPrefab;
		public float shootRate = 0.5f;

		private float lastShootTime;

		private float m_SpriteWidth;
		private InputHandler m_InputHandler;
		private Vector3 m_CurrentVelocity;
		private AMicroGameController m_MicroController;

		private enum MoveState {

			Idle = 0,
			Right = 1,
			Left = 2

		}

		public void OnGameStarted(AMicroGameController microGameController) {
			m_MicroController = microGameController;
			m_SpriteWidth = spaceShipRenderer.bounds.size.x;
			m_InputHandler = FindObjectOfType<InputHandler>();
		}

		private void Update() {
			ProcessInputs();
		}

		private void ProcessInputs() {
			var currentPos = this.transform.position;
			var leftBoundary = mainCamera.ScreenToWorldPoint(Vector3.zero).x + m_SpriteWidth;
			var rightBoundary = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - m_SpriteWidth;

			if (m_InputHandler.Input.x > 0 && currentPos.x < rightBoundary) {
				Move(MoveState.Right);
			}
			else if (m_InputHandler.Input.x < 0 && currentPos.x > leftBoundary) {
				Move(MoveState.Left);
			}
			else {
				Move(MoveState.Idle);
			}

			if (m_InputHandler.Input.y > 0 && Time.time - lastShootTime > shootRate) {
				Shoot();
				lastShootTime = Time.time;
			}
		}

		private void Shoot() {
			var bullet = Instantiate(bulletPrefab, bulletsContainer);
			bullet.transform.position = bulletSpawnTransform.position;
			var bullet2 = Instantiate(bulletPrefab, bulletsContainer);
			bullet2.transform.position = bulletSpawnTransform2.position;
		}

		private void Move(MoveState moveState) {
			var currentPos = this.transform.position;

			switch (moveState) {
				case MoveState.Idle:
					Transform transform1;
					(transform1 = this.transform).DOKill();
					transform1.position = currentPos;
					break;
				case MoveState.Right:
					this.transform.DOMoveX(currentPos.x + spaceShipThurst, spaceShipSpeed);
					break;
				case MoveState.Left:
					this.transform.DOMoveX(currentPos.x - spaceShipThurst, spaceShipSpeed);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(moveState), moveState, null);
			}
		}

		private void OnCollisionEnter2D(Collision2D other) {
			if (other.gameObject.CompareTag("Asteroid")) {

				m_MicroController.OnFailure();
				var summonedExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation);
				summonedExplosion.transform.SetParent(this.transform.parent);
				Destroy(this.gameObject);
				var asteroidExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
				asteroidExplosion.transform.SetParent(other.transform.parent);
				Destroy(other.gameObject);
				
			}
		}

	}

}