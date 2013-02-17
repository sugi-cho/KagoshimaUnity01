using UnityEngine;
using System.Collections;

//放物運動する物体のt秒における位置を計算する。
// y = 1/2*A*x^2 + B*x + C みたいなやつ。
public class Parabola
{
	public static Vector3 GetPositionAtTime (float time, Vector3 initialPosition, Vector3 initialVelosity)
	{
		return Physics.gravity / 2f * time * time + initialVelosity * time + initialPosition;
	}
	
}
