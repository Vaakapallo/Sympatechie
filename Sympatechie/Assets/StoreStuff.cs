using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreStuff : MonoBehaviour {

	public GameObject SplashEffect;
	public GameObject HitEffect;

	// Use this for initialization
	void Awake () {
		//SplashEffect = Resources.Load<GameObject> ("SplashEffect");
	}

	public void CreateSplash(Transform transform){
		Instantiate (SplashEffect, transform.position, Quaternion.identity);
	}

	public void CreateHit(Transform transform){
		Instantiate (HitEffect, transform.position, Quaternion.identity);
	}
}
