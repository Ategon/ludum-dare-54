namespace Auboreal {

	using System.Collections.Generic;
	using System;
	using UnityEngine;

	public class RepairSpaceShip : MonoBehaviour {

		public RepairSpaceShipSettings repairSpaceShipSettings;
		public Transform spaceShipRootTransform;

		private InputHandler m_InputHandler;
		private bool m_CanStartFixing = false;
		private List<GameObject> m_SpawnedSpaceParts = new List<GameObject>();

		public void OnGameStarted() {
			m_InputHandler = FindObjectOfType<InputHandler>();
			SpawnParts();
		}


		private void SpawnParts() {
			var partsEnumCount = Enum.GetValues(typeof(SpaceShipPartType)).Length;

			for (var i = 0; i < partsEnumCount; i++) {
				var partSettings = repairSpaceShipSettings.damagedParts.Parts[i];
				var spaceShipPart = Instantiate(partSettings.SpaceShipPartPrefab, spaceShipRootTransform);
				spaceShipPart.transform.localPosition = partSettings.InitialPosition;
				spaceShipPart.transform.localScale = Vector3.one;
				m_SpawnedSpaceParts.Add(spaceShipPart);
			}

			m_CanStartFixing = true;
		}


		private void Update() {
			if (!m_CanStartFixing) {
				return;
			}

			// D
			if (m_InputHandler.Input.x > 0) {
				ChangePart(3);
			}
			// A
			else if (m_InputHandler.Input.x < 0) {
				ChangePart(1);
			}
			// W
			else if (m_InputHandler.Input.y > 0) {
				ChangePart(0);
			}
			// S
			else if (m_InputHandler.Input.y < 0) {
				ChangePart(2);
			}
		}

		private void ChangePart(int partId) {
			Destroy(m_SpawnedSpaceParts[partId].gameObject);

			var partSettings = repairSpaceShipSettings.repairedParts.Parts[partId];
			var spaceShipPart = Instantiate(partSettings.SpaceShipPartPrefab, spaceShipRootTransform);
			spaceShipPart.transform.localPosition = partSettings.InitialPosition;
			spaceShipPart.transform.localScale = Vector3.one;
			m_SpawnedSpaceParts[partId] = spaceShipPart;
		}

	}

}