using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auboreal
{
    public class Planet : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            FindObjectOfType<DefendMicroGameController>().EndGame(true);
        }
    }
}
