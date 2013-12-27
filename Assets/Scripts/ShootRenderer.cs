using UnityEngine;
using System.Collections;

public class ShootRenderer : MonoBehaviour {
	
	private LineRenderer lineRenderer;
	private int lineIndex = 0;
	public bool shot = false;
	// Use this for initialization
	void Start () {
		//lineRenderer = GetComponent<LineRenderer>();
	}
	
	void Shoot (Vector3 shootPoint) {
		LineRenderer lineRenderer =  GetComponent<LineRenderer>();
//		lineRenderer = (LineRenderer) LineRenderer.Instantiate(GetComponent<LineRenderer>() );
		lineRenderer.SetWidth(0.2f,0.2f);
		lineRenderer.SetPosition(0,transform.position);
		lineRenderer.SetPosition(1,transform.position - shootPoint);	
//		lineIndex++;
		Color red = Color.red;
		red.a = 0.4f;
		lineRenderer.SetColors(red,Color.yellow);	
	}	
	// Update is called once per frame
	void Update () {
	
	}
}
