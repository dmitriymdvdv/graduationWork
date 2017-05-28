using UnityEngine;
using System.Collections;
using System;

public class AiTank : MonoBehaviour {
	
	[HideInInspector]
	public TankController controller;
	
	public float directionSwitcherTime = 2;
	public float shootingTime = 1;
	
	public float _directionSwitcherTimer = 2;
	public float _shootingTimer = 1;
	private Array values;
	private System.Random r;

	void Start () 
	{
		controller = GetComponent<TankController>();
		r = new System.Random ();
		values = Enum.GetValues (typeof(TankController.goDirection));
	}

	void FixedUpdate () 
	{
		_directionSwitcherTimer -= Time.deltaTime;
		_shootingTimer -= Time.deltaTime;
		
		if (_directionSwitcherTimer <= 0)
		{
			var direction = (TankController.goDirection) values.GetValue (r.Next (0, 4));
			_directionSwitcherTimer = directionSwitcherTime;
			controller.direction = direction;
			Debug.Log (controller.direction);
		}
		
		if (_shootingTimer <= 0)
		{
			_shootingTimer = shootingTime;
			controller.Shoot();
		}
	}
}
