using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stplayerLake : MonoBehaviour
{

    FMOD.Studio.EventInstance OST;
    FMOD.Studio.ParameterInstance fullspanning;
    FMOD.Studio.ParameterInstance fullvolume;
    FMOD.Studio.ParameterInstance currentscene;

    public StaminaHealthBarManager shbm;

    void Awake()
    {
        OST = FMODUnity.RuntimeManager.CreateInstance("event:/Music All");
        OST.getParameter("fullspanning", out fullspanning);
        OST.getParameter("fullvolume", out fullvolume);
        OST.getParameter("currentscene", out currentscene);
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
        fullvolume.setValue(0.7f);
        currentscene.setValue(2);

        if (shbm.hunger < 30)
        {
            fullspanning.setValue(1);
        }
        else
        {
            fullspanning.setValue(0);
        }
    }
}
