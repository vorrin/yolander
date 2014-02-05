using UnityEngine;
using System.Collections;

public class RandomManager : MonoBehaviour {
	public GameObject player;
//	public Vector3 startingPos;
//	public Quaternion startingRot;
	public float startingHeight;
	
	// Use this for initialization

	 

	void Start () {
		player = GameObject.Find("body");
//		startingHeight = player.transform.position.y;
		//startingPos =  player.transform.position;
		//startingRot = player.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.R)){
			Debug.Log("ALL ROSES ON THE WESTERN FRONT");
			Application.LoadLevel("yolander");
//			Transform playerTransform = player.transform;
//			playerTransform.position = new Vector3(
//				playerTransform.position.x ,
//				startingHeight,
//				playerTransform.position.z);
//			playerTransform.rotation = new Quaternion(
//				playerTransform.rotation.x,
//				playerTransform.rotation.y,
//				0f,
//				playerTransform.rotation.w);
//			playerTransform.rigidbody.angularVelocity = Vector3.zero;
//			playerTransform.rigidbody.velocity = Vector3.zero;
//


		}
	
	}
}
