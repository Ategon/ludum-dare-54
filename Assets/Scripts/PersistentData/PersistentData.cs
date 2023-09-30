namespace Auboreal {

	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class PersistentData : Singleton<PersistentData> {

		[Header("Objects")]
		public MicroGame[] microgames;

		[Header("Attributes")]
		public int maxHealth = 3;

		[Header("Values")]
		private int currentMicrogame = -1;

		private int score = 0;
		private int health = 0;

		private MicroGame m_currentMicroGame;

		public int Score {
			get => score;
			set {
				score = value;
				EventManager.ScoreChanged(value);
			}
		}

		public int Health {
			get => health;
			set {
				health = value;
				EventManager.HealthChanged(value);
			}
		}

		protected override void Awake() {
			base.Awake();
			health = maxHealth;
		}

		public void SwitchScene(MicroGame microGame, LoadSceneMode loadSceneMode) {
			Debug.Log($"Switch scene {microGame.sceneName}");

			if (m_currentMicroGame != null) {
				var unloadOp = SceneManager.UnloadSceneAsync(m_currentMicroGame.sceneName);
				unloadOp.completed += (op) => LoadNewScene(microGame, loadSceneMode);
			}
			else {
				LoadNewScene(microGame, loadSceneMode);
			}
		}

		private void LoadNewScene(MicroGame microGame, LoadSceneMode loadSceneMode) {
			if (microGame == null) {
				Debug.LogError("MicroGame is null in LoadNewScene.");
				return;
			}

			m_currentMicroGame = microGame;
			SceneManager.LoadSceneAsync(microGame.sceneName, loadSceneMode);
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
			var microGameIndex = UnityEngine.Random.Range(0, microGames.Length);
			return microGames[microGameIndex];
		}

	}

}