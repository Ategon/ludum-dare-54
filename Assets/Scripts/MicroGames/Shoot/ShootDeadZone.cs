namespace Auboreal {

	using UnityEngine;

	public class ShootDeadZone : MonoBehaviour {

		private AMicroGameController m_MicroGameController;

		public void OnGameStarted(AMicroGameController microGameController) {
			m_MicroGameController = microGameController;
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.CompareTag("Asteroid")) {
				m_MicroGameController.lost = true;
			}
		}

	}

}