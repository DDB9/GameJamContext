using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalManager : MonoBehaviour
{
    public Slider hungerGauge;
    public GameObject berries;
    public Transform[] spawnPoints = new Transform[5];

    public float maxTime = 5;
    public float minTime = 2;

    private float time;
    private float spawnTime;


    private void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }
    }

    void Update()
    {
        StartCoroutine(DecreseSlider(hungerGauge));

        if (hungerGauge.value <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }

    void SpawnObject()
    {
        time = 0;
        GameObject berry = Instantiate(berries, spawnPoints[Random.Range(0, spawnPoints.Length)].position, berries.transform.rotation);

        berry.name = "blueberries";
        berry.transform.localScale = new Vector3(15f, 15f, 15f);
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    IEnumerator DecreseSlider(Slider slider)
    {
        if (slider != null)
        {
            float timeSlice = (slider.value / 4500f);
            while (slider.value >= 0)
            {
                slider.value -= timeSlice;
                yield return new WaitForSeconds(1);
                if (slider.value <= 0)

                break;
            }
        }
        yield return null;
    }
}

