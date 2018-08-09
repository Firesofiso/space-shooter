using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMover : MonoBehaviour {

    private Vector3 target;
    private Vector3 direction;
    private float speed;
    public float minSpeed = 1;
    public float maxSpeed = 2;

	// Use this for initialization
	void Start () {
        target = new Vector3(Random.Range(-10, 11), Random.Range(-5, 6), 0);
        direction = target - transform.position;
        speed = Random.Range(minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;



        //transform.Translate(heading * speed * Time.deltaTime);
        transform.Translate(direction.normalized * speed, Space.World);
	}
}
