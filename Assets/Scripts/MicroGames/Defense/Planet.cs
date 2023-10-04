namespace Auboreal {

	using UnityEngine;

	public class Planet : AMicroGameEntity {

		[Header("References")]
		[SerializeField]
		private GameObject explosion;

		public override void OnStart(AMicroGameController mGameController) {
			base.OnStart(mGameController);
		}

		private void OnCollisionEnter2D(Collision2D collision) {
			var summonedExplosion =
				Instantiate(explosion, collision.transform.position, collision.transform.rotation);
			summonedExplosion.transform.SetParent(collision.transform.parent);
			var summonedExplosion2 = Instantiate(explosion, transform.position, transform.rotation);
			summonedExplosion2.transform.SetParent(transform.parent);

			var shield = FindObjectOfType<Shield>();

			var summonedExplosion3 =
				Instantiate(explosion, shield.transform.position, shield.transform.rotation);
			summonedExplosion3.transform.SetParent(shield.transform.parent);

			Destroy(shield.gameObject);
			Destroy(collision.gameObject);
			Destroy(this.gameObject);

			this.microGameController.OnFailure();
		}

		public override void OnEnd() { }

	}

}