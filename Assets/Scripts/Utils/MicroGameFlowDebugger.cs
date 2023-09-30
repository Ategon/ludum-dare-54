namespace Auboreal {

	using UnityEngine;

	public class MicroGameFlowDebugger : MonoBehaviour {

		private void Start() {
			ActionEventSystem.Instance.OnMicroGameLoaded?.Invoke(PersistentData.Instance.GetRandomMicroGame());
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				ActionEventSystem.Instance.OnMicroGameLoaded?
					.Invoke(PersistentData.Instance.GetRandomMicroGame());
			}
		}

	}

}