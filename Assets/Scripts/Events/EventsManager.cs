namespace Auboreal {

	public static class EventManager {

		public delegate void HealthChangedDelegate(float amount);
		public delegate void ScoreChangedDelegate(float amount);
		public delegate void MicroGameSelectedDelegate(PersistentData.MicroGame selectedGame);

		public static event HealthChangedDelegate OnHealthChanged;
		public static event ScoreChangedDelegate OnScoreChanged;
		public static event MicroGameSelectedDelegate OnMicroGameSelected;

		public static void HealthChanged(float amount) {
			OnHealthChanged?.Invoke(amount);
		}

		public static void ScoreChanged(float amount) {
			OnScoreChanged?.Invoke(amount);
		}

		public static void MicroGameSelected(PersistentData.MicroGame selectedGame) {
			OnMicroGameSelected?.Invoke(selectedGame);
		}

	}

}