using TMPro;
using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Auboreal {

	public class CountMicroGameController : AMicroGameController {
		public Count count;
		public CountAsteroidLauncher launcher;
		public TextMeshProUGUI text;

		protected override void OnGameStarted() {
			lost = true;
			base.OnGameStarted();
		}

		protected override void OnGameEnded() {
			if (count.count == launcher.count)
            {
				lost = false;
			}
			text.text = $"You{count.count}\nActual: {launcher.count}";
			text.DOFade(0, 0.2f).SetDelay(0.8f);
			if (lost) PersistentData.Instance.Health -= 1;
			base.OnGameEnded();
		}
	}
}