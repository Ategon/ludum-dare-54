using System.Collections;
using System.Collections.Generic;
using Auboreal;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{
    private InputHandler inputs;
    [SerializeField] private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        inputs = FindObjectOfType<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0, 0, transform.rotation.z - inputs.Input.x * rotationSpeed * Time.deltaTime, transform.rotation.w);
    }
}
