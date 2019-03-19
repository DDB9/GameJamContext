using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropGrowth : MonoBehaviour
{

    public float colliderDestroyTime = 10f;
    
    void Start() {
        // if (!hasRun) {
            StartCoroutine("Grow");
        // }
    }

    IEnumerator Grow() {    
        yield return new WaitForSeconds(5); // From small plant to slightly less small plant.

        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(6); // From slightly less small plant to large plant.

        this.transform.GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(true);

        yield return new WaitForSeconds(7); // From large plant to harvestable crop.

        this.transform.GetChild(2).gameObject.SetActive(false);
        this.transform.GetChild(3).gameObject.SetActive(true);

        //this will destroy the red colliders on the farm, but WON'T destroy the game object itself (because otherwise the veggies will die after that time). 
        //ff dirty gedaan, fixen we later wel
        yield return new WaitForSeconds(colliderDestroyTime);

        
        


        // hasRun = true;
    }
}

