namespace Auboreal {

	public static class EventManager {

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

		public static class Debug {

			public delegate void MicroGameSelectedDelegate(PersistentData.MicroGame selectedGame);

			public static event MicroGameSelectedDelegate OnMicroGameSelected;

			public static void MicroGameSelected(PersistentData.MicroGame selectedGame) {
				OnMicroGameSelected?.Invoke(selectedGame);
			}

		}

	}

}