namespace Auboreal {

	using UnityEngine;

	public abstract class AMicroGameController : MonoBehaviour, IMicroGameFlow {

		public GlobalSettings globalSettings;

		private MicroGameTimer m_MicroGameTimer;
		protected PersistentData.MicroGame MicroGameInstance { get; set; }

		public virtual void Initialize(PersistentData.MicroGame microGameInstance) {
			this.MicroGameInstance = microGameInstance;

			EventManager.Global.OnMicroGameTimerStart += StartMicroGame;
			EventManager.Global.OnMicroGameTimerOver += EndMicroGame;

			m_MicroGameTimer = new MicroGameTimer(globalSettings.timerDuration, microGameInstance);
			m_MicroGameTimer.StartTimer();
		}

		private void Update() {
			m_MicroGameTimer.ProcessTimer();
		}

		public void StartMicroGame(PersistentData.MicroGame microgame) {
			Debug.Log($"MicroGame Started-{microgame.name}");
			OnGameStarted();
		}

		public void EndMicroGame(PersistentData.MicroGame microgame) {
			Debug.Log($"MicroGame Ended-{microgame.name}");
			OnGameEnded();
		}

		protected virtual void OnGameStarted() { }

		protected virtual void OnGameEnded() {
			EventManager.Global.OnMicroGameTimerStart -= StartMicroGame;
			EventManager.Global.OnMicroGameTimerOver -= EndMicroGame;

			EventManager.Global.RequestNextMicroGame();
		}

	}

}