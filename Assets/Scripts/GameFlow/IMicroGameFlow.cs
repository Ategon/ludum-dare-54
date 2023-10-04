namespace Auboreal {

	public interface IMicroGameFlow {

		void StartMicroGame(PersistentData.MicroGame microGame);
		void EndMicroGame(PersistentData.MicroGame microGame);

		void OnSuccess();
		void OnFailure();

	}

}