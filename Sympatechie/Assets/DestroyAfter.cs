using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitAndDestroy ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds (Random.Range (4, 10));
		Destroy (gameObject);
	}
}
