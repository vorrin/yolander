using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
		public Transform player;
		public float distance = 10f;
		public float height = 5f;
		public float delayInCameraChase = 5f;

	
		//[Range(0,5f)] public float lerpValue = 0.5f;
//	 public float timeToCatchUp = 0.5f;
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
			transform.position = new Vector3 (
	            Mathf.Lerp (player.position.x - (player.rigidbody.velocity.x / 1000f), transform.position.x, Time.deltaTime * (delayInCameraChase)), 
	    	    player.position.y + height, 
	            player.position.z - distance);

		}
}
