namespace Auboreal {

	using System.Linq;
	using UnityEngine.SceneManagement;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Networking;
	using System.Collections;

	public class PersistentData : Singleton<PersistentData> {

		[Header("Settings")]
		public GlobalSettings mgGlobalSettings;

		[Header("Objects")]
		public MicroGame[] microgames;

		[Header("Attributes")]
		public int maxHealth = 3;

		[Header("Values")]
		private int currentMicrogame = -1;

		private int m_Score = 0;
		private int m_Health = 0;

		public List<int> localScores = new List<int>();

		private SceneManagerWrapper m_SceneManagerWrapper;
		private readonly List<MicroGame> m_GeneratedMicroGames = new();
		public Dictionary<MicroGameType, MicroGamePersistentState> m_MicroGamesStates = new();

		public bool loadingScores = false;
		public List<ScoreObject> scores;

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
				int old_value = m_Health;
				m_Health = value;
				EventManager.Gameplay.HealthChanged(value, old_value);
			}
		}

		public int GetLocalScoresAbove(int score) {
			return localScores.Where(s => s > score).Count();
		}

		public int GetGlobalScoresAbove(int score) {
			return scores.Where(s => s.score > score).Count();
		}

		public int GetMax() {
			return localScores.Max(t => t);
		}

		protected override void Awake() {
			base.Awake();

			m_SceneManagerWrapper = new SceneManagerWrapper(mgGlobalSettings.intermediateSceneDuration);
			m_Health = maxHealth;
			StartCoroutine(Get());
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
			FuelUp = 8,
			Jump = 9

		}

		public MicroGame GetRandomMicroGame() {
			var microGames = microgames;
			var toRandomFromMicroGames = microGames.Except(m_GeneratedMicroGames).ToArray();

			if (toRandomFromMicroGames.Length <= 0) {
				m_GeneratedMicroGames.Clear();
				toRandomFromMicroGames = microGames;
			}

			var microGameIndex = UnityEngine.Random.Range(0, toRandomFromMicroGames.Length);
			var microGame = toRandomFromMicroGames[microGameIndex];

			CheckMircoGameState(microGame);

			m_GeneratedMicroGames.Add(microGame);
			return microGame;
		}

		private void CheckMircoGameState(MicroGame mGame) {
			if (m_MicroGamesStates.TryGetValue(mGame.gameType, out var state)) {
				m_MicroGamesStates[mGame.gameType].ChangeMicroGameState(MicroGamePersistentState.MicroGameState.NthRun);
			}
			else {
				m_MicroGamesStates.Add(mGame.gameType, new MicroGamePersistentState(mGame));
			}

			Debug.Log($"MicroGame: [{mGame.gameType}] - State: {m_MicroGamesStates[mGame.gameType].GameState}");
		}

		[System.Serializable]
		public class RootObject {

			public List<ScoreObject> scores;

		}

		[System.Serializable]
		public class ScoreObject {

			public int id;
			public int score;

		}

		public IEnumerator Get() {
			UnityWebRequest www = UnityWebRequest.Get("https://pangora.social/api/leaderboard");
			yield return www.SendWebRequest();
			RootObject root = JsonUtility.FromJson<RootObject>(www.downloadHandler.text.Trim('"').Replace("\\", ""));
			scores = root.scores;
			EventManager.Global.PlacementLoaded(GetGlobalScoresAbove(m_Score) + 1, scores.Count());
			www.Dispose();
		}

		public IEnumerator Upload() {
			UnityWebRequest www = UnityWebRequest.Post("https://pangora.social/api/leaderboard",
				System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{{\"score\": {m_Score}}}")));
			www.SetRequestHeader("Content-Type", "application/json");
			yield return www.SendWebRequest();

			if (www.result != UnityWebRequest.Result.Success) {
				Debug.Log(www.error);
			}
			else {
				Debug.Log("Form upload complete!");
			}

			www.Dispose();
		}

	}

}