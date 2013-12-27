using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BackgroundManager : MonoBehaviour {
	public GameObject billBoard; 
	Queue backgroundObjects;
	public float distance = 55f;
	public float heightOnHorizon = 0f;
	private float startinPos;
	public float startingPointX;
	public Queue objects = new Queue();
	public Texture2D[] textures; 
	public GameObject player;
	public Dictionary< GameObject , Vector3> testDict = new Dictionary<GameObject,Vector3 >();

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player");
		
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
		startingPointX = leftMost.x;
		for (int i =0 ; i < 10; i++ ) {
			GameObject mountain = (GameObject) Instantiate(billBoard); 
			mountain.transform.parent = transform;
//			List<Vector3> bundle = new List<Vector3>();
//			if (!if
			testDict.Add (mountain, mountain.transform.localScale);
		//	Dictionary<string,GameObject>
			PlantPrefab( mountain);
			
		}
	}
	
	public virtual void PlantPrefab(GameObject prefab){
		//			terrain.transform.localScale = new Vector3(
		//				Random.Range(.3f,1f) * terrain.transform.localScale.x ,
		//				Random.Range(.3f,1f) * terrain.transform.localScale.y,
		//				Random.Range(.3f,1f) * terrain.transform.localScale.z

		//				);
//		GameObject prefab = prefabBundle[1];
		prefab.renderer.material.SetTexture(0,textures[Random.Range(0, textures.Length)]);
		
		Vector3 originalScale;
		testDict.TryGetValue(prefab,out originalScale);
		prefab.transform.localScale = new Vector3(
			Random.Range(.3f,1.7f) * originalScale.x ,
			Random.Range(.3f,1.7f) * originalScale.y,
			Random.Range(.3f,1.7f) * originalScale.z
			);
		startingPointX = startingPointX +  prefab.transform.localScale.x *.5f ;
		prefab.transform.position = new Vector3( startingPointX , heightOnHorizon,distance);
		startingPointX = startingPointX +  prefab.transform.localScale.x *.5f ;
		objects.Enqueue(prefab);
	}
	
	// Update is called once per frame
	void Update () {
		float dist = player.GetComponent<PlayerStatus>().distanceTraveled;
		GameObject kakka = (objects.Peek() as GameObject);
		if (kakka.transform.position.x +  kakka.renderer.bounds.size.x * 2  < dist ){
			PlantPrefab(objects.Dequeue() as GameObject);
			Debug.Log(testDict.Count);
		}
		
		
		
	}
}
