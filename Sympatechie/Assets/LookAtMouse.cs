﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class LookAtMouse : MonoBehaviour {

	PlatformerCharacter2D control;
	Vector3 startingPosition;
	public bool firing = true;

	// Use this for initialization
	void Start () {
		control = GetComponentInParent<PlatformerCharacter2D> ();
		startingPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg + 90.0f;
		if (!control.m_FacingRight) {
			rot_z += 180;
		}
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);	
	
		if (firing) {
			transform.localPosition = startingPosition + (transform.rotation * new Vector3 (0.15f * Mathf.Sin (Time.time * 9), 0.06f * Mathf.Cos (Time.time * 10), 0.0f));
			int facing = -1;
			if (!control.m_FacingRight) {
				facing = 1;
			}
			control.m_Rigidbody2D.AddForce (transform.rotation * new Vector2 (1.0f, 0.0f) * 50 * facing);
		}
	}
}