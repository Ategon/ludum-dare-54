namespace Auboreal {

	// TODO(Ayoub): Factory needs to support instantiating micro game prefab.
	public static class MicroGameFactory {

		public static AMicroGameController CreateMicroGameController(PersistentData.MicroGame microGame) {
			return microGame.gameType switch {
				PersistentData.MicroGameType.Wait => new WaitMicroGameController(microGame),
				_ => throw new System.Exception("Unsupported game type!")
			};
		}

	}

}