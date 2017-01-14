using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreStuff : MonoBehaviour {

	public GameObject SplashEffect;

	// Use this for initialization
	void Awake () {
		//SplashEffect = Resources.Load<GameObject> ("SplashEffect");
	}

	public void CreateSplash(Transform transform){
		Instantiate (SplashEffect, transform.position, Quaternion.identity);
	}
}
