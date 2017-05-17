using UnityEngine;
using System.Collections;

public class AddScoreOnDestroy : MonoBehaviour {
	
	public static int scrores = 0;
	
	public GUIText mText;
	
	public void TakeDamage(GameObject shooter)
	{
		if ((shooter.GetComponent<AiTank> () != null) && (GetComponent<AiTank> () != null)) {
			return;
		}
		
		scrores++;
		
		mText.text = "scores: " + scrores;
	}
}
