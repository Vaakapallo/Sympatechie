using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class LookAtMouse : MonoBehaviour {

	PlatformerCharacter2D control;
	Vector3 startingPosition;
	public bool firing = true;
	private ChangeImageOnPress UI;
	public GameObject Laser;
	public GameObject Tear;
	private float timer = 0.0f;
	public GameObject Barrel;
	private int counter = 0;

	// Use this for initialization
	void Start () {
		control = GetComponentInParent<PlatformerCharacter2D> ();
		startingPosition = transform.localPosition;
		UI = FindObjectOfType<ChangeImageOnPress> ();
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
	
		if (firing || Input.GetMouseButton (0)) {
			int facing = -1;
			if (!control.m_FacingRight) {
				facing = 1;
			}
			if (UI.gunColor == GunColor.Red) {
				if (!Laser.activeSelf) {
					Laser.SetActive (true);
				}
				transform.localPosition = startingPosition + (transform.rotation * new Vector3 (0.15f * Mathf.Sin (Time.time * 9), 0.06f * Mathf.Cos (Time.time * 10), 0.0f));
			}
			if (UI.gunColor == GunColor.Blue) {
				if (Laser.activeSelf) {
					Laser.SetActive (false);
				}
				timer += Time.deltaTime;
				counter++;
				print (Time.deltaTime);
				if (timer % 0.1 < 0.05) {
					GameObject newBullet = Instantiate (Tear, Barrel.transform.position, Quaternion.identity);
					if (counter % 2 == 0) {
						newBullet.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (-0.2f - 0.2f * Random.value , 1.0f) * 400 * facing);
					} else {
						newBullet.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (0.2f + 0.2f * Random.value, -1.0f) * 400 * facing);
					}
				}
			}
			control.m_Rigidbody2D.AddForce (transform.rotation * new Vector2 (1.0f, 0.0f) * 30 * facing);
		} else {
			if (Laser.activeSelf) {
				Laser.SetActive (false);
			}
		}
	}
}
