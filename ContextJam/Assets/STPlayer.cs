using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STPlayer : MonoBehaviour
{

    FMOD.Studio.EventInstance OST;
    FMOD.Studio.ParameterInstance fullspanning;
    FMOD.Studio.ParameterInstance fullvolume;
    FMOD.Studio.ParameterInstance currentscene;

    public StaminaHealthBarManager shbm;

    public loadwhichscene lws;
    Scene currentScene = SceneManager.GetActiveScene();
    //string sceneName  = currentScene.name;
    string sceneName;


    void Awake()
    {
        OST = FMODUnity.RuntimeManager.CreateInstance("event:/Music All");
        OST.getParameter("fullspanning", out fullspanning);
        OST.getParameter("fullvolume", out fullvolume);
        OST.getParameter("currentscene", out currentscene);
        currentscene.setValue(1);

    }


    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(OST, GetComponent<Transform>(), GetComponent<Rigidbody>());
        OST.start();
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = currentScene.name;
        Debug.Log(SceneManager.GetActiveScene().name);

        fullvolume.setValue(0.7f);

        if (shbm.hunger < 30)
        {
            fullspanning.setValue(1);

        }
        else 
        {
            fullspanning.setValue(0);
        }


        //currentscene.setValue(lws.sceneNumber);
        if (sceneName == "Farm")
        {
            currentscene.setValue(1);
        }
        else if (sceneName == "Lake")
        {
            currentscene.setValue(2);

        }
        else {
            currentscene.setValue(3);
        }
    }
}
