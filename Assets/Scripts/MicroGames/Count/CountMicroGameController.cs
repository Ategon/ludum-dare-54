using TMPro;

namespace Auboreal {

	public class CountMicroGameController : AMicroGameController {
		public Count count;
		public CountAsteroidLauncher launcher;
		public TextMeshProUGUI text;

		protected override void OnGameStarted() {
			base.OnGameStarted();
		}

		protected override void OnGameEnded() {
			if (count.count != launcher.count) lost = true;
			text.text = $"Actual: {launcher.count}";
			base.OnGameEnded();
		}
	}
}