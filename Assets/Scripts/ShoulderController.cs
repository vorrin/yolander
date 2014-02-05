using UnityEngine;
using System.Collections;

public class ShoulderController : MonoBehaviour {
	private Vector3 startingLocalPos; 
	private Vector3 localPos;
	// Use this for initialization
	void Start () {
		startingLocalPos = transform.localPosition;
		localPos = transform.localPosition;
	}

	void FixedUpdate() { 
		localPos = startingLocalPos;
		transform.localPosition = startingLocalPos;
	}
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		Vector3 shoulderPos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 difference =  mousePos - shoulderPos; 
//		Vector3 difference =  shoulderPos - mousePos ; 
		Debug.DrawLine (mousePos, shoulderPos);
		Debug.DrawLine (Vector3.zero,difference);
		
		//THIS WHY WHY WHY, I DONT GET IT WHY WHY WHY 
//		rigidbody.rotation =  Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg ) );
		transform.rotation =  Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg ) );
//		transform.rotation =  Quaternion.Euler(new Vector3(0, 0,  Mathf.Atan2(difference.x,difference.y) * Mathf.Rad2Deg  ) );
//		transform.localRotation.eulerAngles = difference;
//		new Vector3( transform.localRotation.eulerAngles.x , 
//		Vector3.Angle (shoulderPos, mousePos)
//		difference.


//		Vector3 armPointsAtPosition = Camera.main.ScreenToWorldPoint( new Vector3 (mousePos.x, mousePos.y, Camera.main.nearClipPlane)); 
//		Debug.Log ("MAUSPAUS + " + );
//		transform.worldToLocalMatrix.
//		Quaternion newRot = new Quaternion ();
//		newRot.SetLookRotation (armPointsAtPosition);
//		transform.rotation = newRot;
//		transform.LookAt (armPointsAtPosition);

//		transform.localRotation.SetLookRotation (armPointsAtPosition);
	}
}
