namespace Auboreal {

	using UnityEngine;

	public class RepairSpaceShip : MonoBehaviour {

		public RepairSpaceShipSettings repairSpaceShipSettings;
		public Transform spaceShipRootTransform;

		public void OnGameStarted() {
			SpawnParts();
		}

		private void SpawnParts() { }

	}

}