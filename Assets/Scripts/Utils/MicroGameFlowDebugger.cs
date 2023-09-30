namespace Auboreal {

	using UnityEngine;

	public class MicroGameFlowDebugger : MonoBehaviour {

		private void Start() {
			EventManager.MicroGameSelected(PersistentData.Instance.GetRandomMicroGame());
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				EventManager.MicroGameSelected(PersistentData.Instance.GetRandomMicroGame());
			}
		}

	}

}