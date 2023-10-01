namespace Auboreal {

	using System;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Settings/Repair", fileName = "RepairSettings")]
	[Serializable]
	public class RepairSpaceShipSettings : ScriptableObject {

		public RepairedParts repairedParts;
		public RepairedParts damagedParts;

	}


	[Serializable]
	public class SpaceShipParts {

		public SpaceShipPart Part1;
		public SpaceShipPart Part2;
		public SpaceShipPart Part3;
		public SpaceShipPart Part4;

	}

	[Serializable]
	public class SpaceShipPart {

		public SpaceShipPartType SpaceShipPartType;
		public GameObject SpaceShipPartPrefab;
		public Vector3 InitialPosition;

	}

	[Serializable]
	public class RepairedParts : SpaceShipParts { }

	[Serializable]
	public class DamagedParts : SpaceShipParts { }

	[Serializable]
	public enum SpaceShipPartType {

		Part1 = 0,
		Part2 = 1,
		Part3 = 2,
		Part4 = 3

	}

}