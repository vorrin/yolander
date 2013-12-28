using UnityEngine;
using System.Collections;

public class BikeController : MonoBehaviour {
	public Rigidbody backWheel;
	public Rigidbody frontWheel;
	
	[Range(0,100)] public float wheelMaxAngularVelocity;
	// Use this for initialization
	void Start () {
		backWheel.rigidbody.maxAngularVelocity = wheelMaxAngularVelocity;
		frontWheel.rigidbody.maxAngularVelocity = wheelMaxAngularVelocity;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)){
			Debug.Log("PRESS");
			Debug.Log(backWheel.rigidbody.maxAngularVelocity);
			backWheel.AddTorque( -new Vector3(0,0f,1110f) * 100000f, ForceMode.Acceleration);
		}
	}
}
