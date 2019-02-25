using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bb_growth : MonoBehaviour
{
    private int currentState;

    void Start() {
        currentState = 0;
    }

    void Update() {
        switch (currentState){
            case 0:
                StartCoroutine("StageOne");
                break;

            case 1:
                StartCoroutine("StageTwo");
                break;

            case 2:
                break;
        }
    }

    IEnumerator StageOne() {    // From small plant to slightly less small plant.
        yield return new WaitForSeconds(5);

        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);

        currentState++;
    }

    IEnumerator StageTwo() {    // From slightly less small plant to big plant.
        yield return new WaitForSeconds(6);

        this.transform.GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(true);

        currentState++;
    }

    IEnumerator StageThree() {  // From big plant to harvestable crop.
        yield return new WaitForSeconds(7);

        this.transform.GetChild(2).gameObject.SetActive(false);
        this.transform.GetChild(3).gameObject.SetActive(true);
    }
}

