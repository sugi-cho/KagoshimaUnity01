using UnityEngine;
using System.Collections;

public class GoalSoko : MonoBehaviour {

	void OnBallHit(GameObject ball)
	{
		Destroy(ball);
		ScoreCounter.Score++;
		particleSystem.Emit(50);
	}
}
