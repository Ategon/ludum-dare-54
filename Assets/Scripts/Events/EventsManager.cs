namespace Auboreal {

	public static class EventManager {

		public static class GameFlow {

			public delegate void GameStartedDelegate(PersistentData.MicroGame microGame);
			public delegate void GameEndedDelegate(PersistentData.MicroGame microGame);
			public static event GameStartedDelegate OnGameStarted;
			public static event GameEndedDelegate OnGameEnded;
			
			public static void GameStarted(PersistentData.MicroGame microGame) {
				OnGameStarted?.Invoke(microGame);
			}
			
			public static void GameEnded(PersistentData.MicroGame microGame) {
				UnityEngine.Debug.Log($"GameEnded - EventManager");
				OnGameEnded?.Invoke(microGame);
			}
		}

		// TODO(Ayoub): Separate events context even further?
		public static class Gameplay {

			public delegate void HealthChangedDelegate(float amount);
			public delegate void ScoreChangedDelegate(float amount);

			public static event HealthChangedDelegate OnHealthChanged;
			public static event ScoreChangedDelegate OnScoreChanged;

			public static void HealthChanged(float amount) {
				OnHealthChanged?.Invoke(amount);
			}

			public static void ScoreChanged(float amount) {
				OnScoreChanged?.Invoke(amount);
			}

		}

		public static class Input {

			public delegate void AnyInputPressedDelegate();

			public static event AnyInputPressedDelegate OnAnyInputPressed;

			public static void AnyInputPressed() {
				OnAnyInputPressed?.Invoke();
			}

		}

		public static class Debug {

			public delegate void ShowDebugDelegate();

			public static event ShowDebugDelegate OnShowDebugToggled;

			public static void ShowDebugToggled() {
				OnShowDebugToggled?.Invoke();
			}
			
			public delegate void TriggerNextMicroGameDelegate();

			public static event TriggerNextMicroGameDelegate OnTriggerNextMicroGame;

			public static void TriggerNextMicroGame() {
				OnTriggerNextMicroGame?.Invoke();
			}
			
			public delegate void MicroGameSelectedDelegate(PersistentData.MicroGame selectedGame);

			public static event MicroGameSelectedDelegate OnMicroGameSelected;

			public static void MicroGameSelected(PersistentData.MicroGame selectedGame) {
				OnMicroGameSelected?.Invoke(selectedGame);
			}

		}

	}

}