using UnityEngine;
using System.Collections;

public class Parabola
{
	public static Vector3 GetPositionAtTime (float time, Vector3 initialPosition, Vector3 initialVelosity)
	{
		return Physics.gravity / 2f * time * time + initialVelosity * time + initialPosition;
	}
	
}
