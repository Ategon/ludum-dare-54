namespace Auboreal {

	using UnityEngine;

	public class LandPlatformLocator : MonoBehaviour {

		public float langPlatformMaxPosX = -0.45f;
		public float langPlatformMinPosX = 0.45f;
		public Transform landPlatform;

		public Transform bg;

		public void OnGameStarted() {
			var locationRandomizerPosX = Random.Range(langPlatformMinPosX, langPlatformMaxPosX);
			var landPos = landPlatform.position;
			landPos.x = locationRandomizerPosX;
			bg.position = new Vector3(locationRandomizerPosX, bg.position.y, bg.position.z);
			landPlatform.position = landPos;
		}

	}

}