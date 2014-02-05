using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public LayerMask layerMask;
	public float gunForce = 50f;
	
	// Use this for initialization
	void Start () {
	
	}
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
			return;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);	
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask	)){
				Debug.Log("HIT");
                if (hit.collider.name == "MouseToWorldHitPanel"){
					Debug.Log("hI CLIKKATO");
					Debug.DrawLine(transform.position,hit.point, Color.red, 30f);
					//rigidbody.AddForce(
					Vector3 localDirectionVector = ( hit.point - transform.position) + transform.position; 
					Vector3 invertedLocalDirectionVector = ( transform.position - hit.point ) + transform.position;
					Debug.DrawLine(transform.position,invertedLocalDirectionVector, Color.green, 30f);
					Vector3 shootLineVector = invertedLocalDirectionVector - transform.position ;
					rigidbody.AddForce( (shootLineVector).normalized * gunForce );	

					//rigidbody.AddTorque( 
					BroadcastMessage("Shoot", shootLineVector);
					return;
				
				}
			}
            
        }
    }
}
