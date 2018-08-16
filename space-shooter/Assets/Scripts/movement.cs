using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float rotationSpeed = 1;
    public float accelerationCoef = 1;
    private Vector3 currentVelocity = new Vector2();

    private ParticleSystem flame, jet;

	// Use this for initialization
	void Start () {
        flame = transform.GetChild(0).GetComponent<ParticleSystem>();
        jet = transform.GetChild(1).GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        // Rotation stuff
        float rotation = Input.GetAxis("Rotation");
        transform.Rotate(0, rotationSpeed * rotation, 0);

        // Forward movement stuff
        float forwardAxis = Input.GetAxis("Forward Momentum");
        Vector3 accelerationVect = transform.forward * forwardAxis * accelerationCoef;
        float deltaT = Time.deltaTime; // This might not be the right time property.
        
        currentVelocity += accelerationVect * Time.deltaTime;
        Vector3 displacementVect = currentVelocity * Time.deltaTime;
        transform.Translate(displacementVect, Space.World);

        // Increase the size of the flames based of forwardAxis
        ParticleSystem.MainModule flameMain = flame.main;
        flameMain.startSize = (forwardAxis/2);
        ParticleSystem.MainModule jetMain = jet.main;
        jetMain.startSize = (forwardAxis/2) + 0.15f;
    }
}
