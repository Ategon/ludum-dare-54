namespace Auboreal {

	using System.Linq;
	using UnityEngine.SceneManagement;
	using System.Collections.Generic;
	using UnityEngine;

	public class PersistentData : Singleton<PersistentData> {

		[Header("Objects")]
		public MicroGame[] microgames;

		[Header("Attributes")]
		public int maxHealth = 3;

		[Header("Values")]
		private int currentMicrogame = -1;

		private int m_Score = 0;
		private int m_Health = 0;

		private readonly List<MicroGame> m_GeneratedMicroGames = new();
		private readonly SceneManagerWrapper m_SceneManagerWrapper = new SceneManagerWrapper();

		public int Score {
			get => m_Score;
			set {
				m_Score = value;
				EventManager.Gameplay.ScoreChanged(value);
			}
		}

		public int Health {
			get => m_Health;
			set {
				m_Health = value;
				EventManager.Gameplay.HealthChanged(value);
			}
		}

		protected override void Awake() {
			base.Awake();
			m_Health = maxHealth;
		}

		public void SwitchScene(MicroGame microGame, LoadSceneMode loadSceneMode, bool isComingFromMenu) {
			m_SceneManagerWrapper.SwitchScene(microGame, loadSceneMode, isComingFromMenu);
			Score += 1;
		}

		[System.Serializable]
		public class MicroGame {

			[Header("Attributes")]
			public string name;

			public MicroGameType gameType;
			public string instructions;
			public string sceneName;
			public bool disabled = false;

			[Header("Values")]
			public bool dead = false;

		}

		public enum MicroGameType {

			Wait = 0,
			Defend = 1,
			Orbit = 2,
			Mash = 3,
			Shoot = 4,
			Count = 5,
			Land = 6,
			Repair = 7,
			FuelUp = 8

		}

		public MicroGame GetRandomMicroGame() {
			var microGames = microgames;
			var toRandomFromMicroGames = microGames.Except(m_GeneratedMicroGames).ToArray();

			if (toRandomFromMicroGames.Length <= 0) {
				m_GeneratedMicroGames.Clear();
				toRandomFromMicroGames = microGames;
			}

			var microGameIndex = UnityEngine.Random.Range(0, toRandomFromMicroGames.Length);
			m_GeneratedMicroGames.Add(toRandomFromMicroGames[microGameIndex]);
			return toRandomFromMicroGames[microGameIndex];
		}

	}

}