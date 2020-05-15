using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch: MonoBehaviour {
    public GameObject centerObj;

    public GameObject Lamp;
    public Material MaterialOff;
    public Material MaterialOn;

    private float startTime=-1.5f;

    private bool Up = false;
    private bool HandIsTrigger=false;

    public AudioClip AC;

    void Start () {
       // print("初始旋转角度：" + gameObject.transform.localEulerAngles);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.S))
            if (gameObject.transform.localEulerAngles.z < 266)
                gameObject.transform.RotateAround(centerObj.transform.position, Vector3.forward, 0.8f);
        if(Input.GetKeyDown(KeyCode.W))
                if (gameObject.transform.localEulerAngles.z > 251)
                    gameObject.transform.RotateAround(centerObj.transform.position, Vector3.forward, -0.8f);
        if (HandIsTrigger&&Time.time-startTime>=1.5)
        {
            if (!Up)
            {
                if (gameObject.transform.localEulerAngles.z < 266)
                    gameObject.transform.RotateAround(centerObj.transform.position, Vector3.forward, 0.8f);
                else
                {
                    Up = true;
                    HandIsTrigger = false;
                    startTime = Time.time;
                }
            }
            else
            {
                if (gameObject.transform.localEulerAngles.z > 251)
                    gameObject.transform.RotateAround(centerObj.transform.position, Vector3.forward, -0.8f);
                else
                {
                    Up = false;
                    HandIsTrigger = false;
                    startTime = Time.time;
                }
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name.Equals("CubeTrigger"))
        {
            print(other.name+" Trigger Enter");
            AudioSource.PlayClipAtPoint(AC, transform.localPosition);
            Lamp.GetComponent<Light>().enabled = true;
            Lamp.GetComponent<Renderer>().material = MaterialOn;
        }
        else//手触发动作
        {
            HandIsTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("CubeTrigger"))
        {
            print(other.name + " Trigger Exit");
            AudioSource.PlayClipAtPoint(AC, transform.localPosition);
            Lamp.GetComponent<Light>().enabled = false;
            Lamp.GetComponent<Renderer>().material = MaterialOff;
        }
    }
}
