using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashOnHit : MonoBehaviour {

	bool hit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag != "Player" && col.transform.tag != "Bullet" && !hit) {
			hit = true;
			if (col.transform.tag == "Enemy") {
				col.collider.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (1.0f, 0.0f) * -50);
				Color ecolor = col.collider.GetComponent<SpriteRenderer> ().color;
				col.collider.GetComponent<SpriteRenderer> ().color = new Color (ecolor.r - 0.04f, ecolor.g - 0.04f, ecolor.b + 0.04f);
			}
			FindObjectOfType<StoreStuff>().CreateSplash (transform);
			Destroy (gameObject);
		}
	}
}
