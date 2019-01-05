﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnContact : MonoBehaviour {

    public const int asteroidSplitFactor = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            return;
        }

        if (other.tag == "Player")
        {
            // Here is where we reset the scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

		if (other.tag == "Shield" && tag == "Enemy")
		{
			// Destroy the asteroid!
			Destroy(gameObject);
		}

		if (other.tag == "Bullet")
        {
            // Spawn the new asteroids.
            // TODO: Adjust the size of the new asteroids.
            for (int i = 0; i < asteroidSplitFactor; i++)
            {
                Instantiate(gameObject);
            }
            // Destroy the bullet and the asteroid.
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
