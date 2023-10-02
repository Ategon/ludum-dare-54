using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrbitAsteroidLauncher : MonoBehaviour
{
    public GameObject asteroid;
    float timer = 0;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            int rand = Random.Range(0, 3);
            Vector3 pos;

            if (rand == 0)
            {
                pos = new Vector3(0.92f, 0.39f, 0);
            }
            else if (rand == 1)
            {
                pos = new Vector3(0.92f, 0.82f, 0);
            }
            else
            {
                pos = new Vector3(0.92f, 1.26f, 0);
            }

            GameObject summonedAsteroid = Instantiate(asteroid, pos, Quaternion.Euler(0, 0, -45));
            summonedAsteroid.transform.DOMove(pos + new Vector3(-2.5f, -1.26f, 0), 5f);
            timer = 0;
        }
    }
}
