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

    //we need a lose-state as much as we need a win-state
    //the following variables will be used for a starvation mechanic

    private RawImage starvationBar;
    public float starvationTimer = 0;
    public float starvationGainModifier;
    public float starvationReductionModifier;

    public enum playerStates
    {
        NORMAL,
        STARVING,
    }
    playerStates State = playerStates.NORMAL;
    

    


    
    

    

    private void Start()
    {
        staminaBar = GameObject.Find("Stamina").GetComponent<RawImage>();
        hungerBar = GameObject.Find("Hunger").GetComponent<RawImage>();
        starvationBar = GameObject.Find("Starvation").GetComponent<RawImage>();
        
    }

    private void Update()
    {
        staminaBar.transform.localScale = new Vector3(stamina / 100, staminaBar.transform.localScale.y, staminaBar.transform.localScale.z);
        hungerBar.transform.localScale = new Vector3(hunger / 100, hungerBar.transform.localScale.y, hungerBar.transform.localScale.z);
        starvationBar.transform.localScale = new Vector3(starvationTimer / 50, starvationBar.transform.localScale.y, starvationBar.transform.localScale.z);

       
        if(hunger > 25)
        {
            
            staminaHungerRelation = 100 / hunger;
            State = playerStates.NORMAL;
            
        }
        else
        {
            staminaHungerRelation = 4;
            State = playerStates.STARVING;
        }

        if(hunger > 0)
        {
            hunger -= hungerModifier * Time.deltaTime;
        }
        else
        {
            hunger = 0;
        }

        if(hunger > 100)
        {
            hunger = 100;
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
        
        if(starvationTimer >= 50)
        {
            starvationTimer = 50;
            Debug.Log("GAME OVER");
        }

        if (starvationTimer <= 0)
        {
            starvationTimer = 0;
        }

        switch (State)
        {
            case playerStates.STARVING:
                if(starvationTimer < 50)
                {
                    starvationTimer += Time.deltaTime * starvationGainModifier;
                }
                

                break;

            case playerStates.NORMAL:
                if(starvationTimer > 0)
                {
                    starvationTimer -= Time.deltaTime * starvationReductionModifier;
                }
                

                break;

        }


    }   

   
}
