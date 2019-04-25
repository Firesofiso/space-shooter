using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Button startButton;
	public Button optionsButton;
	public Button quitButton;

	// Use this for initialization
	void Start () {
		startButton.onClick.AddListener(StartGame);
		quitButton.onClick.AddListener(QuitGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame() {
		SceneManager.LoadScene(1);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
