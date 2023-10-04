namespace Auboreal {

	using DG.Tweening;
	using UnityEngine;

	public class LandSpaceship : AMicroGameEntity {

		[SerializeField]
		private GameObject explosion;

		public float thrustAmount;
		public float thrustDuration;
		public Transform spaceshipParent;

		private bool m_Landed = false;
		private Rigidbody2D m_Rigidbody2D;
		private InputHandler m_InputHandler;

		public LandMicroGameController con;

		bool pressed = false;
		float randomdir = 0;

		public override void OnStart(AMicroGameController mGameController) {
			base.OnStart(mGameController);
			randomdir = Random.Range(-1, 1);
			TryGetComponent(out m_Rigidbody2D);
			m_InputHandler = FindObjectOfType<InputHandler>();
			m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
		}

		private void Update() {
			if (m_Landed) {
				return;
			}

			var initialPos = this.transform.position;

			if (m_InputHandler.Input.x > 0) {
				this.transform.DOMoveX(initialPos.x + thrustAmount, thrustDuration, false);
				if (!pressed) pressed = true;
			}
			else if (m_InputHandler.Input.x < 0) {
				{
					this.transform.DOMoveX(initialPos.x - thrustAmount, thrustDuration, false);
					if (!pressed) pressed = true;
				}
			}
			else if (!pressed)
            {
				this.transform.DOMoveX(initialPos.x + thrustAmount * randomdir, thrustDuration, false);
			}
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (other.TryGetComponent(out LandPlatform landPlatform)) {
				m_Landed = true;
				m_Rigidbody2D.bodyType = RigidbodyType2D.Static;
				this.microGameController.OnSuccess();
			}
			else if (other.gameObject.CompareTag("Land")) {
				con.lost = true;
				var summonedExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation);
				summonedExplosion.transform.SetParent(this.transform.parent);
				Destroy(this.gameObject);
				this.microGameController.OnFailure();
			}
		}

		public override void OnEnd() { }

	}

}