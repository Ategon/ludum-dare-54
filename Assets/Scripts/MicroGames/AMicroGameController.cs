namespace Auboreal {

	using UnityEngine;

	public abstract class AMicroGameController : MonoBehaviour, IMicroGameFlow {

		private PersistentData.MicroGame MicroGameInstance { get; set; }

		protected virtual void Initialize (PersistentData.MicroGame microGameInstance) {
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

		protected abstract void OnGameStarted();
		protected abstract void OnGameEnded();

	}

}