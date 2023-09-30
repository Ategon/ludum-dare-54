namespace Auboreal {
	using UnityEngine.Events;

	public class ActionEventSystem : Singleton<ActionEventSystem> {

		[System.Serializable]
		public class MicroGameEvent : UnityEvent<PersistentData.MicroGame> { }

		public MicroGameEvent OnMicroGameLoaded;

		protected override void Awake() {
			base.Awake();
			OnMicroGameLoaded ??= new MicroGameEvent();
		}
	}
}