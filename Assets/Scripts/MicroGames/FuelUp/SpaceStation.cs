using System.Collections;
using System.Collections.Generic;
using Auboreal;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{
    private InputHandler inputs;
    [SerializeField] private float rotationSpeed;

    private float moveDir = 1;
    public bool rotate = true;
    // Start is called before the first frame update
    void Start()
    {
        inputs = FindObjectOfType<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputs.Input.x != 0)
            moveDir = inputs.Input.x;
        
        if (rotate)
            transform.rotation = new Quaternion(0, 0, transform.rotation.z - moveDir * rotationSpeed * Time.deltaTime, transform.rotation.w);
        //transform.Rotate(0, 0, transform.rotation.z + moveDir * rotationSpeed * Time.deltaTime);
    }
}
