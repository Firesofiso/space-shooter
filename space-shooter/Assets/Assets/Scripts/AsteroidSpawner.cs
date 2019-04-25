using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public List<GameObject> asteroids = new List<GameObject>();
    public float spawnRate;
    public float spawnAcceleration;
    private const int x = 10;
    private const int y = 6;

	// Use this for initialization
	void Start () {
        StartCoroutine("CreateAsteroid");
	}
	
	// Update is called once per frame
	void Update () {

        
	}

    public IEnumerator CreateAsteroid()
    {
        while (true)
        {
            float randX = Random.Range(-x - 2, x + 3);
            float randY = Random.Range(-y - 2, y + 3);
            int coinFlip = Random.Range(0, 2);

            if (randX >= -x && randX <= x)
            {
                if (coinFlip == 0)
                {
                    randY = Random.Range(y, y + 3);
                }
                else
                {
                    randY = Random.Range(-y, -y - 3);
                }
            }
            else if (randY >= -y && randY <= y)
            {
                if (coinFlip == 0)
                {
                    randX = Random.Range(x, x + 3);
                }
                else
                {
                    randX = Random.Range(-x, -x - 3);
                }
            }

            Vector3 randPos = new Vector3(randX, randY, 0);
            Instantiate(asteroids[0], randPos, Quaternion.identity, transform);

            spawnRate += spawnAcceleration * 1 / spawnRate;
            yield return new WaitForSeconds(1 / spawnRate);
        }
    }
}
