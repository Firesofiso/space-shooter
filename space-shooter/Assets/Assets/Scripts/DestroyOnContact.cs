using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnContact : MonoBehaviour {

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

        if (other.tag == "Bullet")
        {
            // Destroy the bullet and the asteroid.
            // TODO: Make smaller asteroids spawn.
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
