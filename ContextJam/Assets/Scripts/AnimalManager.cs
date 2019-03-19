using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public float speed;

    Vector3 randomDirection;

    // Update is called once per frame
    void Update()
    {
        randomDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
        transform.position += randomDirection * speed * Time.deltaTime;
        transform.LookAt(Vector3.forward);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            speed = -speed; // Invert movement to mimic animals "running away" from player.
        }
    }
}
