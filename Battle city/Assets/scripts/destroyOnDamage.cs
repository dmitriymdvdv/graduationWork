using UnityEngine;
using System.Collections;

public class destroyOnDamage : MonoBehaviour {
	
	public GameObject ExplosionFX;
	
	public GUIText mText;
	public bool isGameOver = false;
	
	public void TakeDamage(GameObject shooter)
	{	
		if (shooter != null && (shooter.GetComponent<AiTank> () != null) && (GetComponent<AiTank> () != null)) {
			return;
		}
		
		if (ExplosionFX != null) {
			Instantiate (ExplosionFX, transform.position, Quaternion.identity);
		}
		
		if (isGameOver)
		{
			mText.gameObject.SetActive(true);
			
		}
		
		DestroyObject(this.gameObject);
	}
}
