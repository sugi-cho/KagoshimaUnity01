using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {
	
	public static int Score;
	
	void OnGUI(){
		GUI.Box(new Rect(0,0,80f,30f), "Score:" + Score.ToString("000"));
	}
}
