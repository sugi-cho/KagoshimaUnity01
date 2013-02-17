using UnityEngine;
using System.Collections;

//ボールが当たった時に、メッセージが送られてくる。
public class GoalSoko : MonoBehaviour {

	void OnBallHit(GameObject ball)
	{
		Destroy(ball);
		ScoreCounter.Score++;
		particleSystem.Emit(50);
	}
}
