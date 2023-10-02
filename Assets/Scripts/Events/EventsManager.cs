namespace Auboreal {

	public static class EventManager {


		public static class UI {

			public delegate void MicroGameTimerChangeDelegate(float time);

			public static event MicroGameTimerChangeDelegate OnMicroGameTimerChange;

			public static void MicroGameTimerChange(float time) {
				OnMicroGameTimerChange?.Invoke(time);
			}

		}
		public static class Global {

			public delegate void RequestNextMicroGameDelegate();

			public static event RequestNextMicroGameDelegate OnRequestNextMicroGame;

			public static void RequestNextMicroGame() {
				OnRequestNextMicroGame?.Invoke();
			}

			public delegate void MicroGameTimerStartDelegate(PersistentData.MicroGame microGame);

			public static event MicroGameTimerStartDelegate OnMicroGameTimerStart;

			public static void MicroGameTimerStart(PersistentData.MicroGame microGame) {
				OnMicroGameTimerStart?.Invoke(microGame);
			}

			public delegate void MicroGameTimerOverDelegate(PersistentData.MicroGame microGame, bool lost = false);

			public static event MicroGameTimerOverDelegate OnMicroGameTimerOver;

			public static void MicroGameTimerOver(PersistentData.MicroGame microGame) {
				OnMicroGameTimerOver?.Invoke(microGame);
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

			public static void CleanInputs() {
				OnAnyInputPressed = null;
			}

		}

		public static class Debug {

			public delegate void TriggerNextMicroGameDelegate();

			public static event TriggerNextMicroGameDelegate OnTriggerNextMicroGame;

			public static void TriggerNextMicroGame() {
				OnTriggerNextMicroGame?.Invoke();
			}

		}

	}

}