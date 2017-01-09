using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOffSet : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.SetFloat ("OffSet", Random.Range (0.0f, 1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
