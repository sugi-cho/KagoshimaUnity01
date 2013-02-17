using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour
{
	
	Transform
		goal, player;
	bool fukan;
	
	// Use this for initialization
	void Start ()
	{
		//GameObject.Find(名前)は、全てのGameObjectにアクセスして指定した名前のオブジェクトを返す。
		//使い過ぎると重いので、Update等毎フレーム呼ばれる所では使わない！
		goal = GameObject.Find ("Goal").transform;
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Space))
			fukan = !fukan;
		
		if (fukan || Input.GetMouseButton(0))
			FukanView ();
		else
			BackView();
	}
	
	//俯瞰視点の設定では、プレイヤーとゴールの位置から動的にカメラの位置を決定している。
	void FukanView ()
	{
		transform.RotateAround(Vector3.up,  30f * Time.deltaTime * Mathf.Deg2Rad);
		Vector3 lookTarget = (goal.position + player.position) / 2f;
		float distance = Vector3.Distance (goal.position, player.position) * 2f;
		
		transform.position = Vector3.Lerp (transform.position, lookTarget - transform.forward * distance, 1.2f);
	}
	
	void BackView(){
		transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, 0.1f);
		transform.position = Vector3.RotateTowards(transform.position, player.position - player.forward*2f + player.right + Vector3.up*2f, 10f, 10f);
	}
}
