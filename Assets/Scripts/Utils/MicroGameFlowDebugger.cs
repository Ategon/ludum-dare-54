namespace Auboreal {

	using UnityEngine;

	public class MicroGameFlowDebugger : MonoBehaviour {

		private void Start() {
			ActionEventSystem.OnMicroGameLoaded?.Invoke(PersistentData.instance.GetRandomMicroGame());
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				ActionEventSystem.OnMicroGameLoaded?
					.Invoke(PersistentData.instance.GetRandomMicroGame());
			}
		}

	}

}