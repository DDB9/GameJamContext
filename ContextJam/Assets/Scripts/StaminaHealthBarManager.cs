using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaHealthBarManager : MonoBehaviour
{
    public float stamina = 100;
    public float hunger = 100;

    //these variables determine the speed of decrease for the 2 bars
    public float staminaHungerRelation;
    public float staminaModifier = 1;
    public float hungerModifier = 0.5f;

    private RawImage staminaBar;
    private RawImage hungerBar;

    


    
    

    

    private void Start()
    {
        staminaBar = GameObject.Find("Stamina").GetComponent<RawImage>();
        hungerBar = GameObject.Find("Hunger").GetComponent<RawImage>();
    }

    private void Update()
    {
        staminaBar.transform.localScale = new Vector3(stamina / 100, staminaBar.transform.localScale.y, staminaBar.transform.localScale.z);
        hungerBar.transform.localScale = new Vector3(hunger / 100, hungerBar.transform.localScale.y, hungerBar.transform.localScale.z);

       
        if(hunger > 25)
        {
            
            staminaHungerRelation = 100 / hunger;
        }
        else
        {
            staminaHungerRelation = 4;
        }

        if(hunger > 0)
        {
            hunger -= hungerModifier * Time.deltaTime;
        }
        else
        {
            hunger = 0;
        }

        if(stamina > 0)
        {
            stamina -= Time.deltaTime * staminaHungerRelation * staminaModifier;
        }
        else
        {
            stamina = 0;
            Debug.Log("End of Day");
        }
        
    }   
}
