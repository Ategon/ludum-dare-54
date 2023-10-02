namespace Auboreal {

	using DG.Tweening;
	using UnityEngine;

	public class ShootBullet : MonoBehaviour {

		public float bulletSpeed = 0.5f;

		private void Update() {
			this.transform.DOMoveY(transform.position.y + bulletSpeed, 2f);
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.CompareTag("Asteroid")) {
				Destroy(other.gameObject);
				Destroy(this.gameObject);
			}
		}

	}

}