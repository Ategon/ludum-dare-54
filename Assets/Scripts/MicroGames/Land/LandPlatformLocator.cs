namespace Auboreal {

	using UnityEngine;

	public class LandPlatformLocator : MonoBehaviour {

		public float langPlatformMaxPosX = -0.45f;
		public float langPlatformMinPosX = 0.45f;
		public Transform landPlatform;

		public void OnGameStarted() {
			var locationRandomizerPosX = Random.Range(langPlatformMinPosX, langPlatformMaxPosX);
			var landPos = landPlatform.position;
			landPos.x = locationRandomizerPosX;
			landPlatform.position = landPos;
		}

	}

}