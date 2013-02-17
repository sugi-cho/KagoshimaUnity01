using UnityEngine;
using System.Collections;

//ボールがColliderに当たると、あたったオブジェクトに対して"OnBallHit"というメッセージを送る。
//すると、そのオブジェクトに割り当てられてるスクリプトのOnBallHit(GameObject)が呼ばれる。
//無かったら何も起きない（DontRequireReceiver）
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

	void OnCollisionEnter (Collision collison)
	{
		collison.gameObject.SendMessage ("OnBallHit", gameObject, SendMessageOptions.DontRequireReceiver);
	}
	
	void OnTriggerEnter (Collider other)
	{
		other.gameObject.SendMessage ("OnBallHit", gameObject, SendMessageOptions.DontRequireReceiver);
	}
	
	IEnumerator Start ()
	{
		yield return new WaitForSeconds(30f);
		if (!rigidbody.IsSleeping ())
			Destroy (gameObject);
	}
}
