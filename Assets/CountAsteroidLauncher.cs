using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CountAsteroidLauncher : MonoBehaviour
{
    public GameObject asteroid;
    float timer = 0;
    float target = 1;
    public int count = 0;
    float totalTimer = 0;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        totalTimer += Time.deltaTime;

        if (totalTimer > 5) return;

        if (timer > target)
        {
            Vector3 pos = new Vector3(-1f, Random.Range(0f, 0.5f), 0);

            GameObject summonedAsteroid = Instantiate(asteroid, pos, Quaternion.Euler(0, 0, 90));
            summonedAsteroid.transform.DOMove(pos + new Vector3(2.5f, 0, 0), 4f);
            timer = 0;
            target = Random.Range(0.2f, 1.5f);
            count += 1;
        }
    }
}
