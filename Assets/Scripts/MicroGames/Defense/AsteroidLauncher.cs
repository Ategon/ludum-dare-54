using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AsteroidLauncher : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject asteroid;

    [Header("Attributes")]
    [SerializeField] private float asteroidSpawnTimeMax = 0.25f;
    [SerializeField] private float asteroidSpawnTimeMin = 0.15f;
    [SerializeField] private float asteroidSpawnOffsetMax = 0.5f;
    [SerializeField] private float asteroidSpawnOffsetMin = -0.5f;

    [Header("Values")]
    private float asteroidSpawnTimer = 0;
    private float asteroidSpawnTarget = 0.25f;

    private void FixedUpdate()
    {
        asteroidSpawnTimer += Time.deltaTime;

        while (asteroidSpawnTimer > asteroidSpawnTarget)
        {
            asteroidSpawnTimer -= asteroidSpawnTarget;
            asteroidSpawnTarget = Random.Range(asteroidSpawnTimeMin, asteroidSpawnTimeMax);

            int side = Random.Range(0, 4);
            float offset = Random.Range(asteroidSpawnOffsetMin, asteroidSpawnOffsetMax);
            Vector3 position = new Vector3(
                    side < 2 ? side == 0 ? 1 : -1 : offset,
                    side > 1 ? side == 2 ? 1 : -1 : offset,
                    0
                );

            GameObject summonedAsteroid = Instantiate(asteroid, position, Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(position.y, position.x) - 90));
            summonedAsteroid.transform.SetParent(transform);

            summonedAsteroid.transform.DOMove(new Vector3(0, 0, 0), 5f);
        }
    }
}
