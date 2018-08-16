using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float RotationSpeed = 1;
    public float AccelerationCoef = 1;
    public float MaxSpeed = 100;
    private Vector3 CurrentVelocity = new Vector2();

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        // Rotation stuff
        float rotation = Input.GetAxis("Rotation");
        transform.Rotate(0, RotationSpeed * rotation, 0);

        // Forward movement stuff
        float fowardAxis = Input.GetAxis("Forward Momentum");
        Vector3 accelerationVect = transform.forward * fowardAxis * AccelerationCoef;
        float deltaT = Time.deltaTime; // This might not be the right time property.
        
        CurrentVelocity += accelerationVect * Time.deltaTime;
        CapVelocity();
        Vector3 displacementVect = CurrentVelocity * Time.deltaTime;
        transform.Translate(displacementVect, Space.World);
	}

    private void CapVelocity()
    {
        if (CurrentVelocity.sqrMagnitude > MaxSpeed * MaxSpeed)
        {
            CurrentVelocity = CurrentVelocity.normalized * MaxSpeed;
        }
    }
}
