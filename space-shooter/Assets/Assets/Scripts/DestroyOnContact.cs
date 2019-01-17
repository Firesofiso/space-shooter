using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnContact : MonoBehaviour
{

    public const int asteroidSplitFactor = 3;
	private UIScript scoreManager;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.Find("UI").GetComponent<UIScript>();
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
            Asteroid asteroidHit = gameObject.GetComponent<Asteroid>();
            if (asteroidHit.Size > AsteroidSizeClass.Small)
            {
                for (int i = 0; i < asteroidSplitFactor; i++)
                {
                    GameObject childAsteroid = Instantiate(gameObject);
                    childAsteroid.GetComponent<Asteroid>().SetSizeFromParent(asteroidHit);
                }
            }
            // Destroy the bullet and the asteroid.
            Destroy(other.gameObject);
			scoreManager.score += 5; // Score Points
			Destroy(gameObject);
        }
    }
}
