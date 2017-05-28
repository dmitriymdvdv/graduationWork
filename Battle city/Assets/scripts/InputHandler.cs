using UnityEngine;
using CnControls;
using System.Collections;

public class InputHandler : MonoBehaviour {
	
	TankController controller;
	TankController.goDirection direction = TankController.goDirection.stay;

	void Start () {
		controller = GetComponent<TankController>();
	}

	void FixedUpdate () {
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			direction = TankController.goDirection.right;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			direction = TankController.goDirection.left;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			direction = TankController.goDirection.up;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			direction = TankController.goDirection.down;
		} else {
			direction = TankController.goDirection.stay;
		}

		if (Input.GetKeyDown(KeyCode.Space) || CnInputManager.GetButtonDown("Jump")) {
			controller.Shoot();
		}

		controller.direction = direction;
	}
}
