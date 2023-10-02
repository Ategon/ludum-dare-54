using TMPro;
using DG.Tweening;

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
			text.text = $"You{count.count}\nActual: {launcher.count}";
			text.DOFade(0, 0.2f).SetDelay(0.8f);
			base.OnGameEnded();
		}
	}
}