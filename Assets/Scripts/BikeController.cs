using UnityEngine;
using System.Collections;

public class BikeController : MonoBehaviour {
	public Rigidbody backWheel;
	public Rigidbody frontWheel;
	public float power;
	public GameObject pilot;
	public Vector3 pilotLocalStandardPos;
	
	[Range(0,100)] public float wheelMaxAngularVelocity;
	// Use this for initialization
	void Start () {
		backWheel.rigidbody.maxAngularVelocity = wheelMaxAngularVelocity;
		frontWheel.rigidbody.maxAngularVelocity = wheelMaxAngularVelocity;
		pilot = GameObject.Find("Pilot") as GameObject;
		pilotLocalStandardPos = pilot.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)){
			FixedJoint joint =  pilot.GetComponent<FixedJoint>();
			Rigidbody connectedBody = 			joint.connectedBody;
			joint.connectedBody = null;
			
			pilot.transform.localPosition = pilotLocalStandardPos + Vector3.left* 2f;
			
			//pilot.transform.position = new Vector3(0.65f,0.88f,0);
			joint.connectedBody = connectedBody;
		}
		else if (Input.GetKeyDown(KeyCode.D)){
			FixedJoint joint =  pilot.GetComponent<FixedJoint>();
			Rigidbody connectedBody = 			joint.connectedBody;
			joint.connectedBody = null;

			pilot.transform.localPosition = pilotLocalStandardPos + Vector3.right;


			//pilot.transform.position = new Vector3(0.65f,0.88f,0);
			joint.connectedBody = connectedBody;
		}
		else if (Input.GetKeyDown(KeyCode.S)){
			FixedJoint joint =  pilot.GetComponent<FixedJoint>();
			Rigidbody connectedBody = 			joint.connectedBody;
			joint.connectedBody = null;
			
			pilot.transform.localPosition = pilotLocalStandardPos ;
			
			
			//pilot.transform.position = new Vector3(0.65f,0.88f,0);
			joint.connectedBody = connectedBody;		
		}

		//GAS AND BRAKE
		if (Input.GetMouseButton(0)){
			Debug.Log("PRESS");
			Debug.Log(backWheel.rigidbody.angularVelocity);
			backWheel.AddTorque( -new Vector3(0,0f, power), ForceMode.Acceleration);
		}
		if (Input.GetMouseButton(1)){
			Debug.Log("PRESS");
			Debug.Log(backWheel.rigidbody.angularVelocity);
			backWheel.AddTorque( new Vector3(0,0f, power), ForceMode.Acceleration);
		}
	}
}
