using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCamera : MonoBehaviour {

    // Use this for initialization
    static WebCamTexture backcam;
	void Start () {
        if (backcam == null)
            backcam = new WebCamTexture();

        GetComponent<Renderer>().material.mainTexture = backcam;

        if (!backcam.isPlaying)
            backcam.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
