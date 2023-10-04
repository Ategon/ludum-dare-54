using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auboreal
{
	public class PassengerShip : MonoBehaviour
	{
		private AMicroGameController m_MicroController;
		[SerializeField] private GameObject explosion;

		private void Start()
		{
			m_MicroController = FindObjectOfType<ShootMicroGameController>();
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("Asteroid"))
			{
				m_MicroController.OnFailure();
				var summonedExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation);
				summonedExplosion.transform.SetParent(this.transform.parent);
				var asteroidExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
				asteroidExplosion.transform.SetParent(other.transform.parent);
				Destroy(other.gameObject);
				Destroy(this.gameObject);
			}
		}
	}
}
