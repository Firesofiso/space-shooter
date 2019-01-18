using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapPosition : MonoBehaviour {

    private Camera Cam;
    public float BufferFactor = 0.05f;
    private int buffer;

	// Use this for initialization
	void Start () {
        //Cam = GetComponent<Camera>(); // this didn't work for some reason...
        Cam = Camera.main;
        buffer = (int)(Cam.pixelHeight * BufferFactor);
	}
	
	// Update is called once per frame
	void Update () {
        // look at Cam.WorldToScreenPoint(), Cam.WorldToViewportPoint, and Cam.worldToCameraMatrix and related...
        Vector3 screenSpaceLoc = Cam.WorldToScreenPoint(transform.position);

        float shiftedX = screenSpaceLoc.x + buffer;
        float shiftedY = screenSpaceLoc.y + buffer;

        // deal with negative values
        if (shiftedX < 0)
        {
            shiftedX = Cam.pixelWidth + buffer;
        }
        if (shiftedY < 0)
        {
            shiftedY = Cam.pixelHeight + buffer;
        }

        int modX = Cam.pixelWidth + (2 * buffer) + 1;
        int modY = Cam.pixelHeight + (2 * buffer) + 1;

        screenSpaceLoc.x = (shiftedX % modX) - buffer;
        screenSpaceLoc.y = (shiftedY % modY) - buffer;
        transform.position = Cam.ScreenToWorldPoint(screenSpaceLoc);
	}
}
