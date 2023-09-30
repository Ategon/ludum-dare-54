namespace Auboreal {

	using UnityEngine;
	using UnityEngine.InputSystem;

	public class InputHandler : MonoBehaviour {

		public Vector2 Input { get; private set; }
		public float Pause { get; private set; }
		public float Restart { get; private set; }

		public void OnInput(InputAction.CallbackContext context) {
			if (context.performed) {
				this.Input = context.ReadValue<Vector2>();
				EventManager.Input.AnyInputPressed();
			}
		}

		public void OnPause(InputAction.CallbackContext context) {
			if (context.performed) {
				this.Pause = context.ReadValue<float>();
			}
		}

		public void OnRestart(InputAction.CallbackContext context) {
			if (context.performed) {
				this.Restart = context.ReadValue<float>();
			}
		}

	}

}