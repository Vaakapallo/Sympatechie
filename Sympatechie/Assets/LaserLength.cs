using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class LaserLength : MonoBehaviour {

	PlatformerCharacter2D control;
	public GameObject LaserHit;
	private ChangeImageOnPress UI;
	private StoreStuff store;
	private int rayMask = 1;

	// Use this for initialization
	void Start () {
		control = GetComponentInParent<PlatformerCharacter2D> ();
		UI = FindObjectOfType<ChangeImageOnPress> ();
		store = FindObjectOfType<StoreStuff> ();
		rayMask |= 1 << LayerMask.NameToLayer ("Player");
		rayMask |= 1 << LayerMask.NameToLayer ("Bullet");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, transform.rotation * new Vector3 (1.0f, 0.0f, 0.0f));
		RaycastHit2D hit;
		if (control) {
			if (control.m_FacingRight) {
				hit = Physics2D.Raycast (transform.position, transform.rotation * (new Vector2 (1.0f, 0.0f)),100,rayMask);
			} else {
				hit = Physics2D.Raycast (transform.position, transform.rotation * (new Vector2 (-1.0f, 0.0f)),100, rayMask);
			}
		} else {
			hit = Physics2D.Raycast (transform.position, transform.rotation * (new Vector2 (1.0f, 0.0f)), 100, rayMask);
		}
		transform.localScale = new Vector3 (-hit.distance/2.9f, transform.localScale.y, transform.localScale.z);
		LaserHit.transform.position = hit.point;
		LaserHit.transform.rotation = Quaternion.Euler (0.0f, 0.0f, Mathf.Min(hit.normal.y * 180, 0) + -hit.normal.x * 90);
	
		if (hit) {
			if (hit.collider.tag == "Enemy") {
				int facing = -1;
				if (control) {
					if (!control.m_FacingRight) {
						facing = 1;
					}
				}
				hit.collider.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (1.0f, 0.0f) * -50 * facing);
				hit.collider.GetComponent<AI> ().AddColor (GunColor.Red);
			} else {
				store.Miss ();
			}
		}
	}	
}
