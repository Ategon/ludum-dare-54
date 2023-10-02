namespace Auboreal {

	using System.Collections;

	public class CoroutineHelper : Singleton<CoroutineHelper> {

		public void StartExternalCoroutine(IEnumerator coroutine) {
			StartCoroutine(coroutine);
		}

	}

}