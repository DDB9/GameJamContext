using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadwhichscene : MonoBehaviour
{
    string sceneName = SceneManager.GetActiveScene().name;
    public int sceneNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;


        if (sceneName == "Farm")
        {
            sceneNumber = 1;
        }
        else if (sceneName == "Lake")
        {
            sceneNumber = 2;
        }
        else
        {
            sceneNumber = 3;        
        }
    }
}
