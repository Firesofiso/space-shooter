using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour {

    public int lifetimeInSeconds;

	// Use this for initialization
	void Start () {
        StartCoroutine(destroyAfterLifetime());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator destroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetimeInSeconds);
        Destroy(gameObject);
    }
}
