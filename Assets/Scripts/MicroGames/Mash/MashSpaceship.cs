using System.Collections;
using System.Collections.Generic;
using Auboreal;
using UnityEngine;

public class MashSpaceship : MonoBehaviour
{
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
        transform.position = new Vector2(transform.position.x + spaceshipSpeed, transform.position.y);
        transform.rotation = new Quaternion(0, 0, transform.rotation.z + Random.Range(-1f, 1f)/60, transform.rotation.w);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PersistentData.Instance.Health--;
        Debug.Log("Lose");
        gameObject.SetActive(false);
    }
}
