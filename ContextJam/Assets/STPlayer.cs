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
    Scene scene;


    void Awake()
    {
        OST = FMODUnity.RuntimeManager.CreateInstance("event:/Music All");
        OST.getParameter("fullspanning", out fullspanning);
        OST.getParameter("fullvolume", out fullvolume);
        OST.getParameter("currentscene", out currentscene);
        currentscene.setValue(1);

        scene = SceneManager.GetActiveScene();

        print(scene.name);

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(OST, GetComponent<Transform>(), GetComponent<Rigidbody>());
        OST.start();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fullvolume.setValue(1);
        currentscene.setValue(1);

        scene = SceneManager.GetActiveScene();
        //print(scene.name);


        if (shbm.starvationTimer > 1)
        {
            fullspanning.setValue(1);
        }
        else 
        {
            fullspanning.setValue(0);
        }

        if (scene.name == "Farm")
        {
            currentscene.setValue(1);
        }
        else if (scene.name == "Lake")
        {
            currentscene.setValue(2);
        }
        else if (scene.name == "Forest")
        {
            currentscene.setValue(3);
        }
    }

	//void OnDestroy()
	//{
 //       OST.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	//}
}
