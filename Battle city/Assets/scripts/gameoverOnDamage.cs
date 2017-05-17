using UnityEngine;
using System.Collections;

public class gameoverOnDamage : MonoBehaviour {
	
	public GUIText mText;
	public GameObject playerTank;
	
	public void TakeDamage(GameObject shooter)
	{	
		mText.gameObject.SetActive(true);
		Time.timeScale = 0;
		DestroyObject(this.gameObject);
		DestroyObject(playerTank);
	}
}
