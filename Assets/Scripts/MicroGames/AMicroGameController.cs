namespace Auboreal {

	using UnityEngine;

	public abstract class AMicroGameController : MonoBehaviour, IMicroGameFlow {

		public GlobalSettings globalSettings;

		private MicroGameTimer m_MicroGameTimer;
		protected PersistentData.MicroGame MicroGameInstance { get; set; }

		public bool lost = false;

		public virtual void Initialize(PersistentData.MicroGame microGameInstance) {
			this.MicroGameInstance = microGameInstance;

			EventManager.Global.OnMicroGameTimerStart += StartMicroGame;
			EventManager.Global.OnMicroGameTimerOver += EndMicroGame;

			m_MicroGameTimer = new MicroGameTimer(globalSettings.timerDuration, microGameInstance);
			m_MicroGameTimer.StartTimer();
		}

		private void Update() {
			m_MicroGameTimer?.ProcessTimer();
		}

		public void StartMicroGame(PersistentData.MicroGame microGame) {
			EventManager.Global.OnMicroGameTimerStart -= StartMicroGame;
			Debug.Log($"MicroGame Started-{microGame.name}");
			OnGameStarted();
		}

		public void EndMicroGame(PersistentData.MicroGame microGame) {
			
			if (lost && microGame.gameType != PersistentData.MicroGameType.Count) PersistentData.Instance.Health -= 1;
			EventManager.Global.OnMicroGameTimerOver -= EndMicroGame;
			Debug.Log($"MicroGame Ended-{microGame.name}");
			OnGameEnded();
		}

		public void OnSuccess() {
			lost = true;
			EndMicroGame(this.MicroGameInstance);
		}

		public void OnFailure() {
			lost = false;
			EndMicroGame(this.MicroGameInstance);
		}

		protected virtual void OnGameStarted() { 
			
		}

		protected virtual void OnGameEnded() {
			EventManager.Global.RequestNextMicroGame();
		}
	}
}