using UnityEngine;
using System.Collections;

public class TerrainManagerTest : BackgroundManager {

//	public GameObject[] prefabs; 
//	Queue backgroundObjects;
//	public float distance = 55f;
//	public float heightOnHorizon = 0f;
//	private float startinPos;
	// Use this for initialization
	public virtual void Start () {
		
	
		Plane theoricPlane = new Plane(new Vector3(0,0,-1),new Vector3( 0, 0 , 55f));
		Ray cameraLeftMostRay = Camera.main.ViewportPointToRay(new Vector3(	0,0.5f ,0));
		float hit;
		Vector3 leftMost = new Vector3(0,0,0);
		if (theoricPlane.Raycast(cameraLeftMostRay, out hit)){
			//				Debug.Log(hit.point);
			leftMost = cameraLeftMostRay.GetPoint(hit);
//			GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			sphere2.transform.position = leftMost;	
//			sphere2.transform.localScale = new Vector3(5f,5f,5f);
		}
		float startingPointX = leftMost.x;
		for (int i =0 ; i < 10; i++ ) {
			GameObject terrain = (GameObject) Instantiate(prefabs[0]); 
//			terrain.transform.localScale = new Vector3(
//				Random.Range(.3f,1f) * terrain.transform.localScale.x ,
//				Random.Range(.3f,1f) * terrain.transform.localScale.y,
//				Random.Range(.3f,1f) * terrain.transform.localScale.z
//				);

			terrain.transform.localScale = new Vector3(
				Random.Range(.3f,1f) * terrain.transform.localScale.x ,
				( Random.Range(.0f,1f) * 15) * terrain.transform.localScale.y,
				 terrain.transform.localScale.z
				);
			startingPointX = startingPointX +  terrain.renderer.bounds.size.x *.5f ;
			terrain.transform.position = new Vector3( startingPointX , heightOnHorizon,distance);
			startingPointX = startingPointX +  terrain.renderer.bounds.size.x *.5f ;
			
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
