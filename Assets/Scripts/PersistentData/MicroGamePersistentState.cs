namespace Auboreal {

	using System;

	[Serializable]
	public class MicroGamePersistentState {

		public enum MicroGameState {

			None = 0,
			FirstRun = 1,
			NthRun = 2

		}

		public MicroGameState GameState { get; set; }
		public PersistentData.MicroGame MicroGame { get; set; }

		public MicroGamePersistentState(PersistentData.MicroGame microGame) {
			this.MicroGame = microGame;
			this.GameState = MicroGameState.FirstRun;
		}

		public void ChangeMicroGameState(MicroGameState mGameState) {
			this.GameState = mGameState;
		}

		public bool IsFirstRun() {
			return (this.GameState == MicroGameState.FirstRun);
		}

	}

}