using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auboreal
{
    public class FuelUpSpaceship : MonoBehaviour
    {
        [SerializeField] private Transform spacestation;
        [SerializeField] private float speed = 10f;
        [SerializeField] private GameObject explosion;

        public FuelUpMicroGameController controller;

        private bool move = true;
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
                collision.transform.GetComponentInParent<SpaceStation>().rotate = false;
                move = false;
                controller.OnSuccess();
            }
            if (collision.gameObject.name == "Spacestation")
            {
                collision.transform.GetComponent<SpaceStation>().rotate = false;
                move = false;
                controller.OnFailure();
                GameObject summonedExplosion = Instantiate(explosion, transform.position, collision.transform.rotation);
                summonedExplosion.transform.SetParent(collision.transform);
                Destroy(gameObject);
            }
        }
    }

}