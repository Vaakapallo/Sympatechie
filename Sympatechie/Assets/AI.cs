using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
		StartCoroutine (ChangeDirection());	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (speed, 0.0f, 0.0f));
	}

	IEnumerator ChangeDirection(){
		yield return new WaitForSeconds (Random.Range (5, 15));
		speed = -speed;
	}
}
