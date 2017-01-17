using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreStuff : MonoBehaviour {

	public GameObject SplashEffect;
	public GameObject HitEffect;
	private LookAtMouse look;
	public GameObject BlowUp;
	public GameObject Bluellet;
	public GameObject LaserCircle;
	public GameObject YellowBullet;

	// Use this for initialization
	void Awake () {
		//SplashEffect = Resources.Load<GameObject> ("SplashEffect");
		look = FindObjectOfType<LookAtMouse>();
	}

	public void CreateSplash(Transform transform){
		Instantiate (SplashEffect, transform.position, Quaternion.identity);
	}

	public void CreateHit(Transform transform){
		Instantiate (HitEffect, transform.position, Quaternion.identity);
	}

	public void Miss(){
		look.Miss ();
	}

	public void CreateExplosion(Transform transform){
		Instantiate (BlowUp, transform.position, Quaternion.identity);
	}

	public void CreateLaserExplosion(Transform transform){
		Instantiate (LaserCircle, transform.position, Quaternion.identity);
	}

	public void YellowExplosion(Transform transform){
		for (int i = 0; i < 20; i++) {
			Instantiate (YellowBullet, transform.position, Quaternion.Euler (0, 0, Random.Range (0, 360)));
		}
	}

	public void BlueExplosion(Transform transform){
		for (int i = 0; i < 30; i++) {
			GameObject newBullet = Instantiate (Bluellet, transform.position, Quaternion.Euler (transform.rotation.eulerAngles));
			if (i % 2 == 0) {
				newBullet.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (-0.5f - 1f * Random.value, 1.0f) * 600);
			} else {
				newBullet.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (0.5f + 1f * Random.value, -1.0f) * 600);
			}		
		}
	}
}
