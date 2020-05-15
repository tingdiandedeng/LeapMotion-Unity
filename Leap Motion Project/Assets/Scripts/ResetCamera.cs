using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCamera : MonoBehaviour {
    public GameObject Cam;
    private float startTime=-1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (startTime==-1&&transform.localEulerAngles.x > 260)
            startTime = Time.time;
        if(startTime!=-1&&(Time.time-startTime)>1)
        {
            Cam.transform.position = new Vector3(0.4f, 0.2f, -2.7f);
            Cam.transform.localEulerAngles = new Vector3(14.1f, 358.6f, 0.0f);
        }
	}
}
