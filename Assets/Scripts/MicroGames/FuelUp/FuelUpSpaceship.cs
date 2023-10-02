using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelUpSpaceship : MonoBehaviour
{
    [SerializeField] private Transform spacestation;
    [SerializeField] private float speed = 10f;

    private bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        /*Vector3 look = transform.InverseTransformPoint(spacestation.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        transform.Rotate(0, 0, angle);*/
        //transform.LookAt(spacestation);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
            transform.position = Vector2.MoveTowards(transform.position, spacestation.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "FuelLocation")
        {
            Debug.Log("Success");
            collision.transform.GetComponentInParent<SpaceStation>().rotate = false;
            move = false;
        }
        if (collision.gameObject.name == "Spacestation")
        {
            Debug.Log("Fail");
            collision.transform.GetComponent<SpaceStation>().rotate = false;
            move = false;
        }
    }
}
