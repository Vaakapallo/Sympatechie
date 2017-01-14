using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class LaserLength : MonoBehaviour {

	PlatformerCharacter2D control;
	public GameObject LaserHit;
	private ChangeImageOnPress UI;

	// Use this for initialization
	void Start () {
		control = GetComponentInParent<PlatformerCharacter2D> ();
		UI = FindObjectOfType<ChangeImageOnPress> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, transform.rotation * new Vector3 (1.0f, 0.0f, 0.0f));
		RaycastHit2D hit;
		if (control.m_FacingRight) {
			hit = Physics2D.Raycast (transform.position, transform.rotation * (new Vector2 (1.0f, 0.0f)));
		} else {
			hit = Physics2D.Raycast (transform.position, transform.rotation * (new Vector2 (-1.0f, 0.0f)));
		}
		transform.localScale = new Vector3 (-hit.distance/2.9f, transform.localScale.y, transform.localScale.z);
		LaserHit.transform.position = hit.point;
		LaserHit.transform.rotation = Quaternion.Euler (0.0f, 0.0f, Mathf.Min(hit.normal.y * 180, 0) + -hit.normal.x * 90);
	
		if (hit) {
			if (hit.collider.tag == "Enemy") {
				int facing = -1;
				if (!control.m_FacingRight) {
					facing = 1;
				}
				hit.collider.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (1.0f, 0.0f) * -50 * facing);
				Color ecolor = hit.collider.GetComponent<SpriteRenderer> ().color;
				if (UI.gunColor == GunColor.Red) {
					hit.collider.GetComponent<SpriteRenderer> ().color = new Color (ecolor.r + 0.01f, ecolor.g - 0.01f, ecolor.b - 0.01f);
				} else if (UI.gunColor == GunColor.Blue) {
					hit.collider.GetComponent<SpriteRenderer> ().color = new Color (ecolor.r - 0.01f, ecolor.g - 0.01f, ecolor.b + 0.01f);
				} else if(UI.gunColor == GunColor.Yellow){
					hit.collider.GetComponent<SpriteRenderer> ().color = new Color (ecolor.r + 0.01f, ecolor.g + 0.01f, ecolor.b - 0.01f);
				}
			}
		}
	}	
}
