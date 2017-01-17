using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashOnHit : MonoBehaviour {

	bool hit = false;
	private StoreStuff logic;

	// Use this for initialization
	void Start () {
		logic = FindObjectOfType<StoreStuff> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag != "Player" && col.transform.tag != "Bullet" && !hit) {
			hit = true;
			if (col.transform.tag == "Enemy") {
				col.collider.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (1.0f, 0.0f) * -50);
				col.collider.GetComponent<AI> ().AddColor (GunColor.Blue);
			} else {
				logic.Miss ();
			}
			logic.CreateSplash (transform);
			Destroy (gameObject);
		}
	}
}
