using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyQuick : MonoBehaviour {

	public float Time = 1.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitAndDestroy ());
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds (Time);
		Destroy (gameObject);
	}
}
