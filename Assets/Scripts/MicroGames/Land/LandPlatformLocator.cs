namespace Auboreal {

	using UnityEngine;

	public class LandPlatformLocator : AMicroGameEntity {

		public float langPlatformMaxPosX = -0.45f;
		public float langPlatformMinPosX = 0.45f;
		public Transform landPlatform;

		public Transform bg;

		public override void OnStart(AMicroGameController mGameController) {
			base.OnStart(mGameController);
			RandomizeLocation();
		}

		private void RandomizeLocation() {
			var locationRandomizerPosX = Random.Range(langPlatformMinPosX, langPlatformMaxPosX);
			var landPos = landPlatform.position;
			landPos.x = locationRandomizerPosX;
			var position = bg.position;
			position = new Vector3(locationRandomizerPosX, position.y, position.z);
			bg.position = position;
			landPlatform.position = landPos;
		}

		public override void OnEnd() { }

	}

}