using UnityEngine;
using System.Collections;

public class ShoulderController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		Vector3 shoulderPos = Camera.main.WorldToScreenPoint (transform.position);
		Debug.Log("screenpoint : " + shoulderPos);
		Vector3 difference =  mousePos - shoulderPos; 
//		Vector3 difference =  shoulderPos - mousePos ; 
		Debug.DrawLine (mousePos, shoulderPos);
		Debug.DrawLine (Vector3.zero,difference);
		
		//THIS WHY WHY WHY, I DONT GET IT WHY WHY WHY 
		transform.rotation =  Quaternion.Euler(new Vector3(0, 0, - Mathf.Atan2(difference.x,difference.y) * Mathf.Rad2Deg + 90f ) );
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
