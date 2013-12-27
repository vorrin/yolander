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
					rigidbody.AddForce( (invertedLocalDirectionVector - transform.position).normalized * gunForce );	
					
					BroadcastMessage("Shoot", invertedLocalDirectionVector - transform.position );
					return;
					LineRenderer lineRenderer =  GetComponent<LineRenderer>();
					lineRenderer.SetWidth(0.2f,0.2f);
					lineRenderer.SetPosition(0,transform.position);
					lineRenderer.SetPosition(1,transform.position - ( invertedLocalDirectionVector - transform.position));	
					Color red = Color.red;
					red.a = 0.4f;
					lineRenderer.SetColors(red,Color.yellow);
					
//					lineRenderer.material.color = new Color(lineRenderer.material.color.r,lineRenderer.material.color.g,lineRenderer.material.color.b,0.3f);	
				}
			}
            
        }
    }
}
