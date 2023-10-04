namespace Auboreal {

	using UnityEngine;

	public class MashSpaceship : AMicroGameEntity {

		[SerializeField]
		private GameObject explosion;

		[SerializeField]
		private Transform sun;

		[SerializeField]
		private float pullSpeed;

		[SerializeField]
		private float spaceshipSpeed;

		public override void OnStart(AMicroGameController mGameController) {
			base.OnStart(mGameController);
		}

		private void Update() {
			this.transform.position = Vector2.MoveTowards(transform.position, sun.position, pullSpeed * Time.deltaTime);
		}

		public void Move() {
			var factor = 1 + (1 - Time.deltaTime) / 3;

			this.transform.position =
				new Vector2(transform.position.x + spaceshipSpeed * factor, this.transform.position.y);

			this.transform.rotation = new Quaternion(0, 0, transform.rotation.z + Random.Range(-1f, 1f) / 60,
				this.transform.rotation.w);

			if (transform.position.x > 1)
            {
				this.microGameController.OnSuccess();
			}
		}

		private void OnTriggerEnter2D(Collider2D collision) {
			var summonedExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation);
			summonedExplosion.transform.SetParent(this.transform.parent);
			Destroy(this.gameObject);
			this.microGameController.OnFailure();
		}

		public override void OnEnd() { }

	}

}