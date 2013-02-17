using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour
{
	
	public Renderer markerPoint;
	public int numMarkers = 10;
	public float timeRange = 5f;
	bool visible = false;
	Renderer[] markers;
	Player player;
	
	public void ToggleVisible ()
	{
		visible = !visible;
		foreach (Renderer r in markers)
			r.enabled = visible;
	}
	
	// Use this for initialization
	void Start ()
	{
		player = (Player)FindObjectOfType (typeof(Player));
		for (int i = 0; i < numMarkers; i++) {
			Renderer r = (Renderer)Instantiate (markerPoint);
			r.transform.parent = transform;
		}
		
		markers = GetComponentsInChildren<Renderer> ();
		for (int i = 0; i < markers.Length; i++) {
			float f = (float)i / (float)numMarkers;
			Color markerColor = markers [i].material.GetColor ("_TintColor");
			markerColor.a = (1 - f) * 0.5f;
			markers [i].material.SetColor ("_TintColor", markerColor);
		}
		
		ToggleVisible ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.M))
			ToggleVisible ();
		
		if (visible) {
			for (int i = 0; i < markers.Length; i++) {
				float f = (float)i / (float)numMarkers;
				float time = f * timeRange;
				markers [i].transform.position = Parabola.GetPositionAtTime (time, player.transform.position, player.initialVelocity);
			}
		}
	}
}
