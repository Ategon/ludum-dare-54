using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIndicator : MonoBehaviour
{
    public bool moving = true;
    public float timer = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!moving) return;

        timer += Time.deltaTime * 1.5f;
        transform.position = new Vector3(0.5f * Mathf.Sin(timer), transform.position.y, transform.position.z);
    }
}
