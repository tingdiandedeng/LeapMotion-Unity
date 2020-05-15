using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("rotation.eulerAngles:"+transform.rotation.eulerAngles);
        print("rotation:" + transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
