using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAudio : MonoBehaviour
{
    FMOD.Studio.EventInstance Music;
    FMOD.Studio.ParameterInstance Volume;

	void Awake()
	{
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/music");
        Music.getParameter("Volume", out Volume);

	}

	void Start()
	{
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Music, GetComponent<Transform>(), GetComponent<Rigidbody>());
        Music.start();
	}

	void Update()
	{
        Volume.setValue(1);
	}

}


