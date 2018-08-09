using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float rotationSpeed = 1;
    public float accelerationCoef = 1;
    private Vector3 currentVelocity = new Vector2();

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        // Rotation stuff
        float rotation = Input.GetAxis("Rotation");
        transform.Rotate(0, rotationSpeed * rotation, 0);

        // Forward movement stuff
        float fowardAxis = Input.GetAxis("Forward Momentum");
        Vector3 accelerationVect = transform.forward * fowardAxis * accelerationCoef;
        float deltaT = Time.deltaTime; // This might not be the right time property.
        
        currentVelocity += accelerationVect * Time.deltaTime;
        Vector3 displacementVect = currentVelocity * Time.deltaTime;
        transform.Translate(displacementVect, Space.World);
	}
}
