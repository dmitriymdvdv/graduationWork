using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public float speed;
	public GameObject owner;

	private Rigidbody rigidbody;

	void Start () {
		rigidbody = GetComponent <Rigidbody> ();
		rigidbody.AddForce(-transform.right * speed, ForceMode.Impulse);
	}
	
	void OnCollisionEnter(Collision col)
	{
		col.gameObject.SendMessage("TakeDamage", this.owner, SendMessageOptions.DontRequireReceiver);
		DestroyObject(gameObject);
	}
}
