using UnityEngine;
using System.Collections;

public class directionSwitcher : MonoBehaviour {
	
	void OnTriggerEnter(Collider col)
	{
		AiTank ai = transform.parent.GetComponent<AiTank>();
		if (ai) {
			if (ai.controller) {
				ai.controller.direction += 1;
			}
		}
	}
}
