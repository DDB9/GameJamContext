using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public float speed;
    private Vector3 randomDirection;

    void Start()
    {
        randomDirection = new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += randomDirection * speed * Time.deltaTime;
        transform.LookAt(Vector3.forward);
        StartCoroutine("ChangeDirection");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            speed = -speed; // Invert movement to mimic animals "running away" from player.
        }
    }

    IEnumerator ChangeDirection()
    {
        randomDirection = new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));
        yield return new WaitForSeconds(3);
    }
}
