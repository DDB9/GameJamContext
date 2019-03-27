using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{

    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;

    public GameObject plantDone;

    public GameObject fakeFood;
    public GameObject allHarvest;


 

    private void Update()
    {
        if (this.transform.GetChild(3).gameObject.activeInHierarchy && !this.transform.GetChild(3).GetChild(3).gameObject.activeInHierarchy)
        {
            StartCoroutine("Delay");
        }
        if (plantDone.activeInHierarchy)
        {
            if (!phase1.activeInHierarchy)
            {
                if (!phase2.activeInHierarchy)
                {
                    if (!phase3.activeInHierarchy)
                    {
                        fakeFood.SetActive(true);
                        allHarvest.SetActive(true);
                    }
                }
            }
        }
        
    }



    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }


}
