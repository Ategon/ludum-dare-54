namespace Auboreal {

	using TMPro;
	using UnityEngine;

	public class UIMicroGameTimer : MonoBehaviour {

		public TextMeshProUGUI microGameTimerTxt;

		private void OnEnable() {
			EventManager.UI.OnMicroGameTimerChange += OnMicroGameTimerChange;
		}

		private void OnDisable() {
			EventManager.UI.OnMicroGameTimerChange -= OnMicroGameTimerChange;
		}

		private void OnMicroGameTimerChange(float time) {
			microGameTimerTxt.text = $"Time Left: {Mathf.RoundToInt(time)}";
		}

	}

}