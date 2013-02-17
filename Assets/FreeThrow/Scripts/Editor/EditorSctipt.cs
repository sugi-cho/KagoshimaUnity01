using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EditorSctipt
{

	[MenuItem("Custom/BuildScene")]
	public static void BuidScene ()
	{
		CreateGoal ();
	}
	
	static Transform CreateGoal ()
	{
		Transform goal = new GameObject ("Goal").transform;
		
		for (int i =0; i < 8; i++) {
			Transform t = GameObject.CreatePrimitive (PrimitiveType.Cube).transform;
			t.parent = goal;
			t.localScale = new Vector3 (0.2f, 3f, 0.1f);
			t.localPosition = new Vector3 (Mathf.Sin (i * Mathf.Deg2Rad * 45f), 0, Mathf.Cos (i * Mathf.Deg2Rad * 45f)) * 0.6f;
			t.localRotation = Quaternion.Euler (0, i * 45f, 0);
		}
		
		Transform soko = GameObject.CreatePrimitive (PrimitiveType.Cylinder).transform;
		soko.parent = goal;
		soko.localScale = new Vector3 (1f, 0.1f, 1f);
		soko.localPosition = -Vector3.up * 1.5f;
		soko.name = "Soko";
		
		return goal;
	}
}
