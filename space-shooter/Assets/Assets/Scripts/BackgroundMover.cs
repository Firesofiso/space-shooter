using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour {

	private Material material;

	// Use this for initialization
	void Start () {
		material = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * 0.05f;
		material.SetTextureOffset("_MainTex", new Vector2(offset, -offset));
	}
}
