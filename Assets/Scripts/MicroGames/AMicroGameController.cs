namespace Auboreal {

	using UnityEngine;

	public abstract class AMicroGameController : MonoBehaviour, IMicroGameFlow {

		protected PersistentData.MicroGame MicroGameInstance { get; set; }

		public virtual void Initialize (PersistentData.MicroGame microGameInstance) {
			this.MicroGameInstance = microGameInstance;
			StartMicroGame();
		}

		public void StartMicroGame() {
			Debug.Log($"MicroGame Started-{this.MicroGameInstance.name}");
			OnGameStarted();
		}

		public void EndMicroGame() {
			Debug.Log($"MicroGame Ended-{this.MicroGameInstance.name}");
			OnGameEnded();
		}

		protected virtual void OnGameStarted() {
			EventManager.GameFlow.GameStarted(this.MicroGameInstance);
		}

		protected virtual void OnGameEnded() {
			EventManager.GameFlow.GameEnded(this.MicroGameInstance);
		}

	}

}