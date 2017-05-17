using System.Collections;
using UnityEngine;

public class CubeFloat : MonoBehaviour {
	
	public float speed, tilt;
	private const float bottomBorder = 1.7f;
	private const float topBorder = 2.7f;
	private Vector3 target = new Vector3(0, topBorder, 0);


	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime * speed);	
		if (transform.position == target && target.y != bottomBorder) {
			target.y = bottomBorder;
		} else if (transform.position == target && target.y == bottomBorder) {
			target.y = topBorder;
		}

		transform.Rotate (Vector3.up * Time.deltaTime * tilt);
	}
}
