using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auboreal
{
	public class Satellite : MonoBehaviour
	{
		private InputHandler m_InputHandler;
		public GameObject explosion;
		int row = 0;
		float timer = 0;
		bool buffer = false;
		float cooldownTimer = 0;
		float cooldown = 0.03f;

		public void OnGameStarted()
		{
			m_InputHandler = FindObjectOfType<InputHandler>();
		}

		private void Update()
		{
			ProcessInputs();
		}

		private void ProcessInputs()
		{
			
			if (buffer == true) return;

			if (m_InputHandler.Input.y > 0 && row < 2)
			{
				row += 1;
				buffer = true;
				cooldownTimer = 0;
			}
			else if (m_InputHandler.Input.y < 0 && row > 0)
			{
				row -= 1;
				buffer = true;
				cooldownTimer = 0;
			}

		}

		private void FixedUpdate()
		{
			cooldownTimer += Time.deltaTime;

			if (m_InputHandler.Input.y != 0)
			{
				cooldownTimer = 0;
			}

			if (cooldownTimer > cooldown && buffer) buffer = false;

			timer += Time.deltaTime;

			transform.position = new Vector3(-0.53f + timer * 0.02f, -0.29f + timer * 0.015f + row * 0.35f, 0);
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			FindObjectOfType<OrbitMicroGameController>().lost = true;
			GameObject summonedExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
			summonedExplosion.transform.SetParent(collision.transform.parent);
			GameObject summonedExplosion2 = Instantiate(explosion, transform.position, transform.rotation);
			summonedExplosion2.transform.SetParent(transform.parent);

			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
