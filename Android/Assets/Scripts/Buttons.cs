using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	public Sprite layer_blue, layer_red;
	public string action;

	void OnMouseDown () {
		GetComponent<SpriteRenderer> ().sprite = layer_red;
	}

	void OnMouseUp () {
		GetComponent<SpriteRenderer> ().sprite = layer_blue;
	}

	void OnMouseUpAsButton () {
		switch (gameObject.name) {
		case "Play":
			Application.LoadLevel ("play");
			break;
		case "Rating":
			Application.OpenURL ("https://google.com");
			break;
		case "Replay":
			Application.LoadLevel ("play");
			break;

		case "Home":
			Application.LoadLevel ("main");
			break;
		case "Facebook":
			Application.OpenURL ("https://facebook.com");
			break;
		}
	}
}
