using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapPosition : MonoBehaviour {

    private Camera Cam;
    public static int buffer;

	// Use this for initialization
	void Start () {
        //Cam = GetComponent<Camera>(); // this didn't work for some reason...
        Cam = Camera.main;
        buffer = Cam.pixelHeight / 20;
	}
	
	// Update is called once per frame
	void Update () {
        // look at Cam.WorldToScreenPoint(), Cam.WorldToViewportPoint, and Cam.worldToCameraMatrix and related...
        Vector3 screenSpaceLoc = Cam.WorldToScreenPoint(transform.position);

        // deal with negative values
        if (screenSpaceLoc.x < 0)
        {
            screenSpaceLoc.x = Cam.pixelWidth + buffer;
        }
        if (screenSpaceLoc.y < 0)
        {
            screenSpaceLoc.y = Cam.pixelHeight + buffer;
        }

        int modX = Cam.pixelWidth + buffer + 1;
        int modY = Cam.pixelHeight + buffer + 1;

        screenSpaceLoc.x = screenSpaceLoc.x % modX;
        screenSpaceLoc.y = screenSpaceLoc.y % modY;
        transform.position = Cam.ScreenToWorldPoint(screenSpaceLoc);
	}
}
