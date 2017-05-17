using UnityEngine;
using System.Collections;

public class AiTank : MonoBehaviour {
	
	[HideInInspector]
	public TankController controller;
	
	public float directionSwitcherTime = 3;
	public float shootingTime = 1;
	
	public float _directionSwitcherTimer = 3;
	public float _shootingTimer = 1;

	void Start () 
	{
		controller = GetComponent<TankController>();
	}

	void Update () 
	{
		_directionSwitcherTimer -= Time.deltaTime;
		_shootingTimer -= Time.deltaTime;
		
		if (_directionSwitcherTimer <= 0)
		{
			_directionSwitcherTimer = directionSwitcherTime;
			controller.direction = (TankController.goDirection) Random.Range(0, 4);
		}
		
		if (_shootingTimer <= 0)
		{
			_shootingTimer = shootingTime;
			controller.Shoot();
		}
	}
}
