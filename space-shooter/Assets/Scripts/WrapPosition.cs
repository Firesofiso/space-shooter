using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapPosition : MonoBehaviour {

    Camera Cam;

	// Use this for initialization
	void Start () {
        Cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        // look at Cam.WorldToScreenPoint(), Cam.WorldToViewportPoint, and Cam.worldToCameraMatrix and related...
        
	}
}
