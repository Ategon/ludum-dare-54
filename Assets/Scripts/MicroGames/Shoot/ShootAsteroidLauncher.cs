namespace Auboreal {

	using System.Collections.Generic;
	using UnityEngine;
	using DG.Tweening;

	public class ShootAsteroidLauncher : MonoBehaviour {

		[Header("References")]
		[SerializeField]
		private GameObject asteroid;

		[Header("Attributes")]
		[SerializeField]
		private float asteroidSpawnTimeMax = 0.25f;

		[SerializeField]
		private float asteroidSpawnTimeMin = 0.15f;

		[SerializeField]
		private float asteroidSpawnOffsetMax = 0.5f;

		[SerializeField]
		private float asteroidSpawnOffsetMin = -0.5f;

		[Header("Values")]
		private float asteroidSpawnTimer = 0;

		private float asteroidSpawnTarget = 0.55f;

		private readonly List<GameObject> m_SpawnedTargets = new();

		private void Update() {
			asteroidSpawnTimer += Time.deltaTime;

			while (asteroidSpawnTimer > asteroidSpawnTarget) {
				asteroidSpawnTimer -= asteroidSpawnTarget;
				asteroidSpawnTarget = Random.Range(asteroidSpawnTimeMin, asteroidSpawnTimeMax);

				var offset = Random.Range(asteroidSpawnOffsetMin, asteroidSpawnOffsetMax);
				var position = new Vector3(offset, 1.4f, 0);
				var summonedAsteroid = Instantiate(asteroid, position, Quaternion.identity);
				summonedAsteroid.transform.SetParent(this.transform);
				m_SpawnedTargets.Add(summonedAsteroid);

				summonedAsteroid.transform.DOMove(new Vector3(offset, -1, 0), 6f);
			}
		}

	}

}