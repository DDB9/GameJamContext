using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstInstance : MonoBehaviour
{
    public GameObject player;
    public GameObject hud;
    public GameObject inventory;
    public GameObject sun;
    public GameObject moon;

    private void Awake() {
        Instantiate(player, transform.position, Quaternion.identity);
        Instantiate(hud, transform.position, Quaternion.identity);
        Instantiate(inventory, transform.position, Quaternion.identity);
        Instantiate(sun, transform.position, Quaternion.identity);
        Instantiate(moon, transform.position, Quaternion.identity);
        
    }
}
