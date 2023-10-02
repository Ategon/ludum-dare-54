using System.Collections;
using System.Collections.Generic;
using Auboreal;
using UnityEngine;

public class MashSpaceship : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    [SerializeField] private Transform sun;
    [SerializeField] private float pullSpeed;
    [SerializeField] private float spaceshipSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, sun.position, pullSpeed * Time.deltaTime);
    }

    public void Move()
    {
        float factor = 1 + (1 - Time.deltaTime) / 4;
        transform.position = new Vector2(transform.position.x + spaceshipSpeed * factor, transform.position.y);
        transform.rotation = new Quaternion(0, 0, transform.rotation.z + Random.Range(-1f, 1f)/60, transform.rotation.w);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<MashMicroGameController>().lost = true;
        var summonedExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation);
        summonedExplosion.transform.SetParent(this.transform.parent);
        Destroy(this.gameObject);
    }
}
