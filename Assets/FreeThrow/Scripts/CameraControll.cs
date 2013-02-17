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
