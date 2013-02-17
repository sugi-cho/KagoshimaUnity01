using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	
	public Ball ball;
	public float
		maxThrowHeight = 2f,
		maxThrowSpeed = 100f,
		moveSpeed = 10f,
		rotateSpeed = 720f;
	
	public Vector3 initialVelocity {
		get {
			Vector3 velocity = transform.forward + Vector3.up * throwHeight;
			return velocity.normalized * throwSpeed;
		}
	}
	
	float throwHeight, throwSpeed, preMousePosX;
	
	// Use this for initialization
	void Start ()
	{
		Vector3 lookVector = GameObject.Find ("Goal").transform.position - transform.position;
		lookVector.y = 0;
		transform.rotation = Quaternion.LookRotation (lookVector);
		preMousePosX = Input.mousePosition.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float deltaMouse = (Input.mousePosition.x - preMousePosX) / Screen.width;
		
		transform.Rotate (Vector3.up, rotateSpeed * deltaMouse);
		
		transform.position += transform.right * moveSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime;
		transform.position += transform.forward * moveSpeed * Input.GetAxis ("Vertical") * Time.deltaTime;
		
		throwHeight = Mathf.Clamp01 (Input.mousePosition.y / Screen.height) * maxThrowHeight;
		
		if (Input.GetMouseButtonDown (0))
			throwSpeed = 0;
		else if (Input.GetMouseButton (0))
			throwSpeed += Time.deltaTime * maxThrowSpeed / 3f;
		else if (Input.GetMouseButtonUp (0))
			ThrowBall ();
		else
			throwSpeed = Mathf.Lerp (throwSpeed, maxThrowSpeed * 0.5f, 0.1f);
		
		preMousePosX = Input.mousePosition.x;
	}
	
	void ThrowBall ()
	{
		Ball shootBall = (Ball)Instantiate (ball, transform.position, transform.rotation);
		shootBall.rigidbody.velocity = initialVelocity;
	}
}
