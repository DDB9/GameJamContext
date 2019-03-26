//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;


//public class STstopper : MonoBehaviour
//{

//    FMOD.Studio.EventInstance OST;


//    void Awake()
//    {
//        OST = FMODUnity.RuntimeManager.CreateInstance("event:/Music All");

//    }


//    // Start is called before the first frame update
//    void Start()
//    {
//        //FMODUnity.RuntimeManager.AttachInstanceToGameObject(OST, GetComponent<Transform>(), GetComponent<Rigidbody>());
//        OST.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    void OnDestroy()
//    {
//    }
//}
