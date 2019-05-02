using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	

    public GameObject gun;
    public GameObject bullet, bulletContainer;
	public GameObject shield;

	[HideInInspector]
	public float shieldValue = 100;
	private Coroutine shieldCoroutine;

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

		if (Input.GetButtonDown("Shield1") && shieldValue > 0) {
			// Player presses down the shield button to activate the shield
			shield.SetActive(true);
			shieldCoroutine = StartCoroutine(DepleteShield());
			
			// Make sure every time the player activates the shield it rotates in a random direction
			shield.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * shield.GetComponent<Done_RandomRotator>().tumble;
		}

		if (Input.GetButtonUp("Shield1") || shieldValue <= 0)
		{
			// Deactivate the shield whenever the player lets go of the shield button.
			shield.SetActive(false);
			StopCoroutine(shieldCoroutine);
			StartCoroutine(RegenerateShield());
		}
	}

	public IEnumerator DepleteShield() {
		while (true) {
			shieldValue--;
			yield return new WaitForSeconds(0.05f);
		}
	}

	public IEnumerator RegenerateShield() {
		while (shieldValue < 100 && !shield.activeInHierarchy) {
			shieldValue++;
			yield return new WaitForSeconds(0.25f);
		}
	}
}
