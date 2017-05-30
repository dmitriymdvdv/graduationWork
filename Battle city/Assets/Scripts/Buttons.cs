using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	public string action;
	public GameObject pausePanel;

	void OnMouseDown () {
	}

	void OnMouseUp () {
	}

	void OnMouseUpAsButton () {
		Time.timeScale = 1.0f;
		switch (gameObject.name) {
		case "Single":
		case "RestartButton":
			Application.LoadLevel ("Tanks");
			break;
		case "MenuButton":
			Application.LoadLevel ("Main");
			break;
		case "Multyplayer":
			Application.LoadLevel ("TanksMulty");
			break;
		case "Exit":
			Application.Quit ();
			break;
		case "Pause":
			pausePanel.SetActive (true);
			Time.timeScale = 0;
			break;
		case "ResumeButton":
			pausePanel.SetActive (false);
			Time.timeScale = 1.0f;
			break;
		}
	}
}
