namespace Auboreal {

	using System.Collections.Generic;
	using System;
	using UnityEngine;

	public class RepairSpaceShip : AMicroGameEntity {

		public RepairSpaceShipSettings repairSpaceShipSettings;
		public Transform spaceShipRootTransform;

		private InputHandler m_InputHandler;
		private bool m_CanStartFixing = false;
		private List<GameObject> m_SpawnedSpaceParts = new List<GameObject>();

		public GameObject explosion;

		List<int> partsFixed = new List<int>();

		int wantedPartsFixed = 4;

		bool dead = false;

		float bufferTimerLeft;
		float bufferTimerRight;
		float bufferTimerUp;
		float bufferTimerDown;

		private void SpawnParts() {
			var partsEnumCount = Enum.GetValues(typeof(SpaceShipPartType)).Length;
			SpaceShipPart partSettings;

			for (var i = 0; i < partsEnumCount; i++) {
				if (UnityEngine.Random.Range(0, 4) == 0 && partsFixed.Count < 3)
                {
					partSettings = repairSpaceShipSettings.repairedParts.Parts[i];
					partsFixed.Add(i);
				}
				else
                {
					partSettings = repairSpaceShipSettings.damagedParts.Parts[i];
				}
				var spaceShipPart = Instantiate(partSettings.SpaceShipPartPrefab, spaceShipRootTransform);
				spaceShipPart.transform.localPosition = partSettings.InitialPosition;
				spaceShipPart.transform.localScale = Vector3.one;
				m_SpawnedSpaceParts.Add(spaceShipPart);
			}

			m_CanStartFixing = true;
		}


		private void Update() {
			if (dead) return;
			if (!m_CanStartFixing) {
				return;
			}

			bufferTimerLeft += Time.unscaledDeltaTime;
			bufferTimerRight += Time.unscaledDeltaTime;
			bufferTimerUp += Time.unscaledDeltaTime;
			bufferTimerDown += Time.unscaledDeltaTime;

			// D
			if (m_InputHandler.Input.x > 0 && bufferTimerRight > 0.1f) {
				ChangePart(3);
			}
			// A
			else if (m_InputHandler.Input.x < 0 && bufferTimerLeft > 0.1f) {
				ChangePart(1);
			}
			// W
			else if (m_InputHandler.Input.y > 0 && bufferTimerUp > 0.1f) {
				ChangePart(0);
			}
			// S
			else if (m_InputHandler.Input.y < 0 && bufferTimerDown > 0.1f) {
				ChangePart(2);
			}

			if (m_InputHandler.Input.x < 0)
			{
				bufferTimerLeft = 0;
				
			} else if (m_InputHandler.Input.x > 0)
			{
				bufferTimerRight = 0;

			}

			if (m_InputHandler.Input.y < 0)
			{
				bufferTimerDown = 0;
			} else if (m_InputHandler.Input.y > 0)
			{
				bufferTimerUp = 0;
			}
		}

		private void ChangePart(int partId) {
			if (partsFixed.Contains(partId))
            {
				// explode
				dead = true;

				GameObject summonedExplosion3 = Instantiate(explosion, transform.position, transform.rotation);
				summonedExplosion3.transform.SetParent(transform.parent);

				this.microGameController.OnFailure();
				Destroy(gameObject);
				return;
            }
			partsFixed.Add(partId);

			Destroy(m_SpawnedSpaceParts[partId].gameObject);

			var partSettings = repairSpaceShipSettings.repairedParts.Parts[partId];
			var spaceShipPart = Instantiate(partSettings.SpaceShipPartPrefab, spaceShipRootTransform);
			spaceShipPart.transform.localPosition = partSettings.InitialPosition;
			spaceShipPart.transform.localScale = Vector3.one;
			m_SpawnedSpaceParts[partId] = spaceShipPart;

			if (partsFixed.Count == 4)
            {
				FindObjectOfType<RepairMicroGameController>().lost = false;
				this.microGameController.OnSuccess();
			}
		}

		public override void OnStart(AMicroGameController mGameController)
		{
			base.OnStart(mGameController);

			m_InputHandler = FindObjectOfType<InputHandler>();
			SpawnParts();
		}


		public override void OnEnd() { }

	}

}