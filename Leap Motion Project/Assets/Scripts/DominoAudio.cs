using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoAudio : MonoBehaviour {
    public AudioClip AC;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision) 
    {
        //print(collision.collider.name);
        AudioSource.PlayClipAtPoint(AC, transform.localPosition);
    } 
}
