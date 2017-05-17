using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	
	public int count = 2;
	public float time = 8;
	float timer;
	public bool onStart = true;
	public GameObject prefab;
	public GameObject FX;

	void Start () {
		timer = time;
		if (onStart) {
			Spawn ();
		}
	}

	void Update () {
		timer -= Time.deltaTime;
		
		if (timer <= 0) {
			timer = time;
			if (count <= 0) {
				this.enabled = false;
				return;
			}
			Spawn();
		}
	}
	
	void Spawn()
	{
		count--;
		Instantiate(prefab, transform.position, Quaternion.identity);
		Instantiate(FX, transform.position, Quaternion.identity);
	}
}
