using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmHUD : MonoBehaviour
{
    public Collider2D localCollider;

    private void Start()
    {
        localCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D localCollider)
    {
    
    }
}
