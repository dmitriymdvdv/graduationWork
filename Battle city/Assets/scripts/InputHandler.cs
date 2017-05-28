using UnityEngine;
using CnControls;
using System.Collections;
using System;

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

		MobileMove ();

		if (Input.GetKeyDown(KeyCode.Space) || CnInputManager.GetButtonDown("Jump")) {
			controller.Shoot();
		}

		controller.direction = direction;
	}

	private void MobileMove () {
		Vector3 movement = new Vector3 (CnInputManager.GetAxis ("Horizontal"), 0f, CnInputManager.GetAxis ("Vertical"));
		if (movement != Vector3.zero) {
			float x = movement.x;
			float y = movement.z;

			if (x < 0 && y < 0) {
				if (Math.Abs (x) > Math.Abs(y)) {
					direction = TankController.goDirection.left;
				} else {
					direction = TankController.goDirection.down;
				}
			} else if (x > 0 && y > 0) {
				if (Math.Abs (x) > y) {
					direction = TankController.goDirection.right;
				} else {
					direction = TankController.goDirection.up;
				}
			} else if (x > 0 && y < 0) {
				if (Math.Abs (x) > Math.Abs (y)) {
					direction = TankController.goDirection.right;
				} else {
					direction = TankController.goDirection.down;
				}
			} else if (x < 0 && y > 0) {
				if (Math.Abs (x) > y) {
					direction = TankController.goDirection.left;
				} else {
					direction = TankController.goDirection.up;
				}
			}
		}
	}
}
