using Assets.Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnContact : MonoBehaviour
{

    public const int asteroidSplitFactor = 3;
	private UIScript headsUpDisplay;

	// Use this for initialization
	void Start () {
		headsUpDisplay = GameObject.Find("UI").GetComponent<UIScript>();
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            return;
        }

		if (other.tag == "Shield" && tag == "Enemy")
		{
			// Destroy the asteroid!
			Destroy(gameObject);
		}

		if (other.tag == "Player")
        {
			// Negate damage if the player has their shield up.
			if (!other.GetComponent<Player>().shield.activeInHierarchy) {
                // lose a life
                headsUpDisplay.lives--;
                // If 0 lives, then go to game over scene
                if (headsUpDisplay.lives <= 0)
                {
                    SceneManager.LoadScene(SceneConstants.GameOver);
                }
                // Otherwise reset player ship with temporary shield
                var spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
                other.transform.SetPositionAndRotation(spawnPoint.transform.position, spawnPoint.transform.rotation);
                other.GetComponent<Movement>().currentVelocity = Vector3.zero;
			}
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
			headsUpDisplay.score += 5; // Score Points
			Destroy(gameObject);
        }
    }
}
