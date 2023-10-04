namespace Auboreal {

	using UnityEngine;

	public abstract class AMicroGameEntity : MonoBehaviour {

		protected AMicroGameController microGameController;

		public virtual void OnStart(AMicroGameController mGameController) {
			this.microGameController = mGameController;
		}


		public abstract void OnEnd();

	}

}