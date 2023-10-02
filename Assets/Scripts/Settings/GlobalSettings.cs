namespace Auboreal {

	using System;
	using UnityEngine;

	[Serializable]
	[CreateAssetMenu(menuName = "Global/Settings", fileName = "GlobalSettings")]
	public class GlobalSettings : ScriptableObject {

		[Header("Timer")]
		public float timerDuration = 6f;

	}

}