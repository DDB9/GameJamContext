using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{

    private void Update()
    {
        if (this.transform.GetChild(3).gameObject.activeInHierarchy && !this.transform.GetChild(3).GetChild(0).gameObject.activeInHierarchy)
        {
            StartCoroutine("Delay");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }


}
