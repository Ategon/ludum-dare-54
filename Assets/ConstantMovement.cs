using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    public float speed;
    public Vector3 dir;

    void FixedUpdate()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
