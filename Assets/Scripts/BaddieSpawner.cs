using UnityEngine;
using System.Collections;

public class BaddieSpawner : MonoBehaviour {
	public float minSpawnTime = 0.5f;
	public float maxSpawnTime = 1f;
	private float nextSpawnCounter = 1f;
	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		nextSpawnCounter = Random.Range(minSpawnTime,maxSpawnTime);
	}

	void FixedUpdate() {
		transform.position = new Vector3( player.transform.position.x + (-6.137722f), transform.position.y, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		nextSpawnCounter -= Time.deltaTime;
		if (nextSpawnCounter <= 0){
			nextSpawnCounter = Random.Range(minSpawnTime,maxSpawnTime);
			GameObject baddie = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			baddie.AddComponent<Rigidbody>();
			baddie.transform.position = transform.position;
			Debug.Log(player.transform.position - transform.position);
			Debug.DrawLine(transform.position, transform.position+  player.transform.position - transform.position , Color.white,5f);
			baddie.rigidbody.velocity = ( player.rigidbody.velocity) ; 
		}
	}
}
