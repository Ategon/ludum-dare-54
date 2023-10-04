using UnityEngine;
using System.Collections;

namespace Auboreal {

	

	public abstract class AMicroGameController : MonoBehaviour, IMicroGameFlow {

		public GlobalSettings globalSettings;

		private MicroGameTimer m_MicroGameTimer;
		protected PersistentData.MicroGame MicroGameInstance { get; set; }

		public bool lost = false;
		public bool ended = false;

		public virtual void Initialize(PersistentData.MicroGame microGameInstance) {
			this.MicroGameInstance = microGameInstance;

			EventManager.Global.OnMicroGameTimerStart += StartMicroGame;
			EventManager.Global.OnMicroGameTimerOver += EndTimer;

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

		public void EndTimer(PersistentData.MicroGame microGame)
		{
			if (ended) return;
			ended = true;
			EndMicroGame(microGame);
		}

		public void EndMicroGame(PersistentData.MicroGame microGame) {
			
			if (lost && microGame.gameType != PersistentData.MicroGameType.Count) PersistentData.Instance.Health -= 1;
			EventManager.Global.OnMicroGameTimerOver -= EndMicroGame;
			Debug.Log($"MicroGame Ended-{microGame.name}");
			OnGameEnded();
		}

		public void OnSuccess() {
			if (ended) return;
			lost = false;
			ended = true;
			StartCoroutine(endGame());
		}

		public void OnFailure() {
			if (ended) return;
			lost = true;
			ended = true;
			StartCoroutine(endGame());
		}

		protected virtual void OnGameStarted() { 
			
		}

		protected virtual void OnGameEnded() {
			EventManager.Global.RequestNextMicroGame();
		}

		IEnumerator endGame()
        {
			yield return new WaitForSeconds(1.0f);
			EndMicroGame(this.MicroGameInstance);
		}
	}
}