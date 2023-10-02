namespace Auboreal {

	using DG.Tweening;
	using UnityEngine;

	public class LandSpaceship : MonoBehaviour {

		[SerializeField] private GameObject explosion;

		public float thrustAmount;
		public float thrustDuration;
		public Transform spaceshipParent;

		private bool m_Landed = false;
		private Rigidbody2D m_Rigidbody2D;
		private InputHandler m_InputHandler;

		public LandMicroGameController con;

		public void OnGameStarted() {
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
			}
			else if (m_InputHandler.Input.x < 0) {
				{
					this.transform.DOMoveX(initialPos.x - thrustAmount, thrustDuration, false);
				}
			}
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (other.TryGetComponent(out LandPlatform landPlatform)) {
				m_Landed = true;
				m_Rigidbody2D.bodyType = RigidbodyType2D.Static;
				con.lost = false;
			}else if (other.gameObject.CompareTag("Land")) {
				con.lost = true;
				var summonedExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation);
				summonedExplosion.transform.SetParent(this.transform.parent);
				Destroy(this.gameObject);
			}
		}

	}

}