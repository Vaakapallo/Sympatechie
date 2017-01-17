using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoStraight : MonoBehaviour {

	private bool hit = false;
	private StoreStuff logic;

	// Use this for initialization
	void Start () {
		logic = FindObjectOfType<StoreStuff> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.rotation * Vector2.right * 2 * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag != "Player" && col.transform.tag != "Bullet" && !hit) {
			hit = true;
			if (col.transform.tag == "Enemy") {
				col.collider.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (1.0f, 0.0f) * -50);
				col.collider.GetComponent<AI> ().AddColor (GunColor.Yellow);
			} else {
				logic.Miss ();
			}
			FindObjectOfType<StoreStuff>().CreateHit (transform);
			Destroy (gameObject);
		}
	}
}
