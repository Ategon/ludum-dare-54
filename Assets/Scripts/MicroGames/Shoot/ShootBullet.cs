namespace Auboreal {

	using DG.Tweening;
	using UnityEngine;

	public class ShootBullet : MonoBehaviour {

		public float bulletSpeed = 0.5f;
		public GameObject explosion;

		private void FixedUpdate() {
			this.transform.position = new Vector3(transform.position.x, transform.position.y + bulletSpeed * Time.deltaTime, transform.position.z);
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.CompareTag("Asteroid")) {
				if (transform.position.y >= 0.9)
                {
					Destroy(this.gameObject);
				}
				else
                {
					var summonedExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
					summonedExplosion.transform.SetParent(other.transform.parent);
					Destroy(other.gameObject);
					Destroy(this.gameObject);
				}
			}
		}

	}

}