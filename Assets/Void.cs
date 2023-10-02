using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auboreal
{
    public class Void : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            FindObjectOfType<LandMicroGameController>().EndGame(true);
        }
    }
}
