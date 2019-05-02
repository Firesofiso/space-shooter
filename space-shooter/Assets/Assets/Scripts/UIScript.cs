using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public long score = 0;

	public GameObject scoreText;
	public Image shieldBarUI;

	public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.GetComponent<TextMeshProUGUI>().text = "" + score;
		shieldBarUI.fillAmount = player.shieldValue / 100;
	}
}
