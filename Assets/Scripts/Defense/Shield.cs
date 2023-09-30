using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private InputHandler inputs;

    private void Start()
    {
        inputs = FindObjectOfType<InputHandler>();
    }

    private void Update()
    {
        if (inputs.Input.x > 0)
        {
            transform.position = new Vector3(0.25f, 0, 0);
            transform.rotation = new Vector3(0, 0, 90);
        }
        else if (inputs.Input.x < 0)
        {
            transform.position = new Vector3(-0.25f, 0, 0);
        }
        else if (inputs.Input.y > 0)
        {
            transform.position = new Vector3(0, 0.25f, 0);
        }
        else if (inputs.Input.y < 0)
        {
            transform.position = new Vector3(0, -0.25f, 0);
        }
    }
}
