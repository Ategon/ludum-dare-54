namespace Auboreal {

	using System;
	using UnityEngine;

	[Serializable]
	[CreateAssetMenu(menuName = "Global/Settings", fileName = "GlobalSettings")]
	public class GlobalSettings : ScriptableObject {

		[Header("Timer")]
		public float timerDuration = 6f;
		
		[Header("Intermediate Scene Timer")]
		public float intermediateSceneDuration = 3f;

	}

}