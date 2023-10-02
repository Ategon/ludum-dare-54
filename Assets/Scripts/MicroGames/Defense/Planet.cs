using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auboreal
{
    public class Planet : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject explosion;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            FindObjectOfType<DefendMicroGameController>().lost = true;
            GameObject summonedExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            summonedExplosion.transform.SetParent(collision.transform.parent);
            GameObject summonedExplosion2 = Instantiate(explosion, transform.position, transform.rotation);
            summonedExplosion2.transform.SetParent(transform.parent);

            Shield shield = FindObjectOfType<Shield>();
            GameObject summonedExplosion3 = Instantiate(explosion, shield.transform.position, shield.transform.rotation);
            summonedExplosion3.transform.SetParent(shield.transform.parent);

            Destroy(shield.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
