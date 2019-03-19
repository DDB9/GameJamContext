using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAudio : MonoBehaviour
{
    FMOD.Studio.EventInstance Music;
    FMOD.Studio.ParameterInstance Volume;
    FMOD.Studio.ParameterInstance Spanning;


    StaminaHealthBarManager SHBM;

	void Awake()
	{
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/music");
        Music.getParameter("Volume", out Volume);
        Music.getParameter("Spanning", out Spanning);
        SHBM = GameObject.Find("HUD").GetComponent<StaminaHealthBarManager>();
	}

	void Start()
	{
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Music, GetComponent<Transform>(), GetComponent<Rigidbody>());
        Music.start();
	}

	void Update()
	{
        Volume.setValue(1);
        Spanning.setValue(SHBM.hunger);
	}

}


