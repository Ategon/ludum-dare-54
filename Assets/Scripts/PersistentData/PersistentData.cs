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
				EventManager.Gameplay.ScoreChanged(value);
			}
		}

		public int Health {
			get => health;
			set {
				health = value;
				EventManager.Gameplay.HealthChanged(value);
			}
		}

		protected override void Awake() {
			base.Awake();
			health = maxHealth;
		}

		public void SwitchScene(MicroGame microGame, LoadSceneMode loadSceneMode) {
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
			SceneManager.sceneLoaded += OnMicroGameSceneLoaded;
			SceneManager.LoadSceneAsync(microGame.sceneName, loadSceneMode);
		}

		private void OnMicroGameSceneLoaded(Scene microGameScene, LoadSceneMode sceneMode) {
			SceneManager.sceneLoaded -= OnMicroGameSceneLoaded;
			
			var controller = FindObjectOfType<AMicroGameController>();
			if (controller != null) {
				controller.Initialize(m_currentMicroGame);
			} else {
				Debug.LogError($"No MicroGameController found in scene: {microGameScene.name}");
			}
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