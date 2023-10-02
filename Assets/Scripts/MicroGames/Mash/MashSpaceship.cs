using System.Collections;
using System.Collections.Generic;
using Auboreal;
using UnityEngine;

public class MashSpaceship : MonoBehaviour
{
    /*[SerializeField] private Transform sun;
    [SerializeField] private float speed;
    [SerializeField] private float maxDist;
   
    private InputHandler inputs;
    private MashMicroGameController controller;
    // Start is called before the first frame update
    void Start()
    {
        inputs = FindObjectOfType<InputHandler>();
        controller = FindObjectOfType<MashMicroGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(controller.Input);
        //transform.position = new Vector2(transform.position.x + Mathf.Abs(inputs.Input.x) + Mathf.Abs(inputs.Input.y), transform.position.y);
        //transform.position = Vector2.MoveTowards(transform.position, sun.position, speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - sun.position.x) < maxDist)
        {
            gameObject.SetActive(false);
            Debug.Log("Lose");
        }
    }*/
}
