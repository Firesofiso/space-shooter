using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float rotationSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float rotation = Input.GetAxis("Rotation");
        //Vector3 currentRotation = transform.eulerAngles;
        //Vector3 delta = new Vector3(0, 0, rotaton);
        transform.Rotate(0, rotationSpeed * rotation, 0);
	}
}
