using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject spawned;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnPerInterval ());
		print ("starting");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnPerInterval(){
		print ("Enumarator starting");
		while (true) {
			print ("while starting");
			yield return new WaitForSeconds (Random.Range(5, 10));
			Instantiate (spawned, transform.position, Quaternion.identity);
		}
	}
}
