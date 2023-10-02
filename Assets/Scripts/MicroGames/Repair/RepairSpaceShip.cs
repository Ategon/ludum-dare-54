namespace Auboreal {

	using System;
	using UnityEngine;

	public class RepairSpaceShip : MonoBehaviour {

		public RepairSpaceShipSettings repairSpaceShipSettings;
		public Transform spaceShipRootTransform;

		public void OnGameStarted() {
			SpawnParts();
		}

		private void SpawnParts() {
			var partsEnumCount = Enum.GetValues(typeof(SpaceShipPartType)).Length;

			for (var i = 0; i < partsEnumCount; i++) {
				var partSettings = repairSpaceShipSettings.repairedParts.Parts[i];
				var spaceShipPart = Instantiate(partSettings.SpaceShipPartPrefab,spaceShipRootTransform);
				spaceShipPart.transform.localPosition = partSettings.InitialPosition;
				spaceShipPart.transform.localScale = Vector3.one;
			}
		}

	}

}