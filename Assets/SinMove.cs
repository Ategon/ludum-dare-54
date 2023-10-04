using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : MonoBehaviour
{
    public float amplitude;
    public float speed;

    private float startingy;

    private float offset;

    private void Start()
    {
        startingy = transform.localPosition.y;

        offset = Random.Range(0, Mathf.PI * 2);
    }

    private void FixedUpdate()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, startingy + Mathf.Sin(Time.time * speed + offset) * amplitude, transform.localPosition.z);
    }
}
