using UnityEngine;
using System.Collections;

//ボールを投げた時の軌跡を表示する。
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
	//最初に、numMarkersの分だけ、markerPointのオブジェクトを作る。
	
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
			//遠くのものほどアルファが薄くなるように指定している。
			//マテリアルは自由にプロパティの名前を付けれて、スクリプトから、
			//"_TintColor"というColorプロパティの値を指定する。
			//プロパティ名を知るには、Shaderソースを見る。
			//Unityに元からあるマテリアルのソースはUnityのサイトからダウンロード出来る。
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
				//Paraboraは独自に作ったクラスで、最初の位置と初速度を与えたときの放物運動する物体の指定した時刻での位置を返す。
				markers [i].transform.position = Parabola.GetPositionAtTime (time, player.transform.position, player.initialVelocity);
			}
		}
	}
}
