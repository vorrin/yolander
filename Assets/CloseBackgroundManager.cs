using UnityEngine;
using System.Collections;

public class CloseBackgroundManager : MonoBehaviour {
	public GameObject[] prefabs; 
	Queue backgroundObjects;
	public float distance = 55f;
	private float startinPos;
	// Use this for initialization
	void Start () {
		
//		Plane teoricPlane = new Plane(new Vector3(0,0,-1),new Vector3( 0, 0 , 55f));
		Debug.Log("vec 3 up : " + Vector3.up);	
		
		
		
		for (int j = 0 ; j <11; j++){
//			Plane theoricPlane = new Plane(new Vector3(0,0,-1),new Vector3( 0, 0 , 55f));
//			Ray cameraLeftMostRay = Camera.main.ViewportPointToRay(	new Vector3(0f,(j/10f		),0));
//			float hit;
//			if (theoricPlane.Raycast(cameraLeftMostRay, out hit)){
////				Debug.Log(hit.point);
//				leftMost = cameraLeftMostRay.GetPoint(hit);
//				GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//				sphere2.transform.position = leftMost;	
//				sphere2.transform.localScale = new Vector3(5f,5f,5f);
//			}
//			
			
			
			
			Vector3 leftmostWorldPoint = Camera.main.ViewportToWorldPoint(new Vector3(0f,(j/10f		),distance));
			
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.transform.position = leftmostWorldPoint;	
			sphere.transform.localScale = new Vector3(5f,5f,5f);
			Debug.Log(leftmostWorldPoint);
			
		}
		
		//GameObject.Instantiate("Sphere",leftmostWorldPoint, transform.rotation);
		Debug.Log("CHECK ME OUT");
		Plane theoricPlane = new Plane(new Vector3(0,0,-1),new Vector3( 0, 0 , 55f));
		Ray cameraLeftMostRay = Camera.main.ViewportPointToRay(new Vector3(	0,0.5f ,0));
		float hit;
		Vector3 leftMost = new Vector3(0,0,0);
		if (theoricPlane.Raycast(cameraLeftMostRay, out hit)){
//				Debug.Log(hit.point);
			leftMost = cameraLeftMostRay.GetPoint(hit);
			GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere2.transform.position = leftMost;	
			sphere2.transform.localScale = new Vector3(5f,5f,5f);
		}
		float startingPointX = leftMost.x;
		for (int i =0 ; i < 10; i++ ) {
			GameObject mountain = (GameObject) Instantiate(prefabs[0]); 
			mountain.transform.localScale = new Vector3(
				Random.Range(.3f,1f) * mountain.transform.localScale.x ,
				Random.Range(.3f,1f) * mountain.transform.localScale.y,
				Random.Range(.3f,1f) * mountain.transform.localScale.z
				);
			startingPointX = startingPointX +  mountain.transform.localScale.x *.5f ;
			mountain.transform.position = new Vector3( startingPointX , -15f,distance);
			startingPointX = startingPointX +  mountain.transform.localScale.x *.5f ;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
