using UnityEngine;
using System.Collections;

public class BikeController : MonoBehaviour {
	public Rigidbody backWheel;
	public Rigidbody frontWheel;
	public float power;
	
	[Range(0,100)] public float wheelMaxAngularVelocity;
	// Use this for initialization
	void Start () {
		backWheel.rigidbody.maxAngularVelocity = wheelMaxAngularVelocity;
		frontWheel.rigidbody.maxAngularVelocity = wheelMaxAngularVelocity;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton(0)){
			Debug.Log("PRESS");
			Debug.Log(backWheel.rigidbody.angularVelocity);
			backWheel.AddTorque( -new Vector3(0,0f, power), ForceMode.Acceleration);
		}
	}
}
