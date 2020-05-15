using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {
    public GameObject Cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnCollisionEnter(Collision collision)
    {
        //print(collision.collider.name);
        if (collision.collider.name.Equals("Domino(1)"))
        {
            Cam.transform.position=new Vector3(1.6f, 1.1f, -0.6f);
            Cam.transform.localEulerAngles = new Vector3(32.5f, 269.6f, 0.000f);
        }

    }
}
