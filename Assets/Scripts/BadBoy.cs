using UnityEngine;
using System.Collections;

public class BadBoy : MonoBehaviour {
	public float timeToLive = 2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeToLive -= Time.deltaTime;
		if (timeToLive <= 0){
			DestroyObject(gameObject);
		}
	}
}
