using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{

    FMOD.Studio.EventInstance MusicEvent;
    FMOD.Studio.ParameterInstance Volume;
    FMOD.Studio.ParameterInstance Spanning;

    public StaminaHealthBarManager Stahea;

	void Awake()
	{
        MusicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
        MusicEvent.getParameter("Volume", out Volume);
        MusicEvent.getParameter("Spanning", out Spanning);
	}

	// Start is called before the first frame update
	void Start()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(MusicEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        MusicEvent.start();
    }

    // Update is called once per frame
    void Update()
    {
        Volume.setValue(1);
        if (Stahea.hunger > 30){
            Spanning.setValue(1);
        }
        else {
            Spanning.setValue(0);
        }
    }
}
