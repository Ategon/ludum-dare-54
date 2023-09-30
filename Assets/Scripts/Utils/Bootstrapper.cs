namespace Auboreal {

	using UnityEngine;

	public static class Bootstrapper {

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Boot()
			=> Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load(@"Prefabs/Systems")));

	}

}