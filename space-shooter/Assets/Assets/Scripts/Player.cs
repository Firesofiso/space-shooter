using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject gun;
    public GameObject bullet, bulletContainer;
	public GameObject shield;

	// Use this for initialization
	void Start () {
        bulletContainer = GameObject.Find("BulletContainer");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate(bullet, bulletContainer.transform, true);
            Instantiate(bullet, gun.transform.position, transform.rotation, bulletContainer.transform);
        }

		if (Input.GetButtonDown("Shield1")) {
			// Player presses down the shield button to activate the shield
			shield.SetActive(true);
			
			// Make sure every time the player activates the shield it rotates in a random direction
			shield.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * shield.GetComponent<Done_RandomRotator>().tumble;
		}

		if (Input.GetButtonUp("Shield1"))
		{
			// Deactivate the shield whenever the player lets go of the shield button.
			shield.SetActive(false);
		}
	}
}
