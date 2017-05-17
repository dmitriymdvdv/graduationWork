using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankController : MonoBehaviour {
	
	public enum goDirection { up = 0, down = 180, left = -90, right = 90, stay};
	public goDirection direction;
	
	public float speed;
	public GameObject mBullet;
	bool shouldGo = false;
	private Rigidbody rigidbody;
	private Animation animation;

	Quaternion initialRot;

	void Start () 
	{
		rigidbody = GetComponent <Rigidbody> ();
		animation = GetComponent <Animation> ();
		initialRot = transform.rotation;
	}
	
	void FixedUpdate()
	{
		rigidbody.velocity = Vector3.zero;

		if (direction == goDirection.right || direction == goDirection.left || direction == goDirection.up || direction == goDirection.down) {
			Move ((int)direction);
		}

		if (!animation.IsPlaying("shoot") && !animation.IsPlaying("idle")) {
			animation.Play("idle");
		}
	}

	private void Move (float y) 
	{
		transform.rotation = initialRot;
		transform.Rotate(new Vector3(0, y, 0));
		rigidbody.AddForce(-transform.right * speed, ForceMode.Impulse);
	}


	public void Shoot()
	{
		animation.Play("shoot");
		GameObject bullet = Instantiate(mBullet, transform.position + -transform.right * 7, this.transform.rotation) as GameObject;
		(bullet.GetComponent<Bullet>() as Bullet).owner = this.gameObject;
	}
}
