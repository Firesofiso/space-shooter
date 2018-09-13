using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject gun;
    public GameObject bullet, bulletContainer;

	// Use this for initialization
	void Start () {
        bulletContainer = GameObject.Find("BulletContainer");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, bulletContainer.transform, false);
        }
	}
}
