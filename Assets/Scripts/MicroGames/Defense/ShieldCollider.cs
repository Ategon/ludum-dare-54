namespace Auboreal {

	using UnityEngine;

	public class ShieldCollider : MonoBehaviour {

		[Header("References")]
		[SerializeField]
		private GameObject explosion;

		private void OnCollisionEnter2D(Collision2D collision) {
			var summonedExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
			summonedExplosion.transform.SetParent(collision.transform.parent);
			Destroy(collision.gameObject);
		}

	}

}