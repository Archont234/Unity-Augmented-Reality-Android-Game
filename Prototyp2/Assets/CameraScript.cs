using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

    // Use this for initialization
    static WebCamTexture backCam;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (backCam == null)
        {
            backCam = new WebCamTexture();
        }
        GetComponent<RawImage>().texture = backCam;
        backCam.Play();
    }
}
