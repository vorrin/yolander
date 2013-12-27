using UnityEngine;
using System.Collections;

public class BaddieSpawner : MonoBehaviour {
	public float minSpawnTime = 0.5f;
	public float maxSpawnTime = 1f;
	private float nextSpawnCounter = 1f;
	public GameObject player;
	public float aimingRandomness = 4f;
	public GameObject[] baddies ;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		nextSpawnCounter = Random.Range(minSpawnTime,maxSpawnTime);
	}

	void FixedUpdate() {
		transform.position = new Vector3( player.transform.position.x + (-6.137722f), transform.position.y, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		nextSpawnCounter -= Time.deltaTime;
		if (nextSpawnCounter <= 0){
			nextSpawnCounter = Random.Range(minSpawnTime,maxSpawnTime);
			GameObject baddie = Instantiate(baddies[Random.Range(0,baddies.Length)]) as GameObject;
			Vector3 spawnPosition = transform.position ;
			
			//			baddie.AddComponent<Rigidbody>();
			baddie.transform.position = spawnPosition;
//			Debug.Log(player.transform.position - spawnPosition);
//			Debug.DrawLine(spawnPosition, player.transform.position , Color.white,5f);
//			baddie.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ| RigidbodyConstraints.FreezeRotationX| RigidbodyConstraints.FreezeRotationY| RigidbodyConstraints.FreezeRotationZ ;
//			Debug.Log(player.rigidbody.velocity);
			Vector3 aimingPosition = new Vector3(player.transform.position.x, player.transform.position.y + Random.Range(-aimingRandomness,aimingRandomness),player.transform.position.z);
			baddie.rigidbody.velocity = (player.transform.position - ( spawnPosition ) )* Random.Range(0.6f,2f) +  player.rigidbody.velocity ;
//			baddie.rigidbody.velocity =  ; 
		}
	}
}
