using System.Collections;
using System.Collections.Generic;
using UnityEngine;


float oldPos;

void Start()
{
    oldPos = transform.position.x;
}

void Update()
{
    if (oldPos < transform.position.x)
    {
        print("moving right");
    }
    if (oldPos > transform.position.x)
    {
        print("moving left");
    }
    oldPos = transform.position.x;
}