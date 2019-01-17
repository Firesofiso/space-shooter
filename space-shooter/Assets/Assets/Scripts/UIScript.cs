using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour {

	public long score = 0;

	public GameObject scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.GetComponent<TextMeshProUGUI>().text = "" + score;
	}
}
