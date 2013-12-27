using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public float distanceTraveled;
	private float startingX; 
	// Use this for initialization
	void Start () {
		distanceTraveled = 0f;
		startingX = transform.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {
		distanceTraveled = transform.position.x - startingX; 
	}
}
