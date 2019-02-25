using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bb_growth : MonoBehaviour
{
    bool hasRun = false;
    
    void Start(){
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

        // hasRun = true;
    }
}

