using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour {

    public float duration = 1;
    public float speed = 100;
    public Quaternion startRotation;
    public Quaternion targetRotation;

	// Use this for initialization
	void Start () {
        //targetRotation = Random.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        //var step = 100 * speed * Time.deltaTime;
        //transform.Rotate(new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)), Space.Self);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        //if (transform.rotation == targetRotation) targetRotation = Random.rotation;
	}
}
