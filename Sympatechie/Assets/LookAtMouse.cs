using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class LookAtMouse : MonoBehaviour {

	PlatformerCharacter2D control;

	// Use this for initialization
	void Start () {
		control = GetComponentInParent<PlatformerCharacter2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg + 90.0f;
		if (!control.m_FacingRight) {
			rot_z += 180;
		}
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);	}
}
