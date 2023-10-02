using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelUpSpaceship : MonoBehaviour
{
    [SerializeField] Transform spacestation;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 look = transform.InverseTransformPoint(spacestation.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        transform.Rotate(0, 0, angle);
        //transform.LookAt(spacestation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
