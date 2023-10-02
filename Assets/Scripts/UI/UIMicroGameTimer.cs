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
			if (time > 3 && microGameTimerTxt.gameObject.active)
            {
				microGameTimerTxt.gameObject.SetActive(false);
			}
			else if (time <= 3 && !microGameTimerTxt.gameObject.active)
			{
				microGameTimerTxt.gameObject.SetActive(true);
			}

			microGameTimerTxt.text = $"{Mathf.Ceil(time)}";
		}

	}

}