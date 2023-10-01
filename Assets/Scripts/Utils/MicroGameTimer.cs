namespace Auboreal {

	using UnityEngine;

	public class MicroGameTimer {

		private bool m_IsTimerRunning = false;
		private float m_MicroGameDuration;
		private float m_MicroGameTimerElapsed = 0f;
		private PersistentData.MicroGame m_CurrentMicroGame;

		public MicroGameTimer(float microGameDuration, PersistentData.MicroGame currentMicroGame) {
			m_MicroGameDuration = microGameDuration;
			m_CurrentMicroGame = currentMicroGame;
		}

		public void StartTimer() {
			m_MicroGameTimerElapsed = 0;
			m_IsTimerRunning = true;
			EventManager.Global.MicroGameTimerStart(m_CurrentMicroGame);
		}

		public void ResetTimer() {
			m_IsTimerRunning = false;
			EventManager.Global.MicroGameTimerOver(m_CurrentMicroGame);
		}

		public bool ProcessTimer() {
			if (m_IsTimerRunning) {
				m_MicroGameTimerElapsed += Time.deltaTime;

				if (m_MicroGameTimerElapsed >= m_MicroGameDuration) {
					ResetTimer();
					return true;
				}
			}

			return false;
		}

	}

}