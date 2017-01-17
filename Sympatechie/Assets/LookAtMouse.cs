using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class LookAtMouse : MonoBehaviour
{

	PlatformerCharacter2D control;
	Vector3 startingPosition;
	public bool firing = true;
	private ChangeImageOnPress UI;
	public GameObject Laser;
	public GameObject Tear;
	public GameObject Frustration;
	private float timer = 0.0f;
	public GameObject Barrel;
	private int counter = 0;
	private float RedAmmo = 30f;
	private float BlueAmmo = 30f;
	private float YellowAmmo = 30f;

	public Text RedText;
	public Text BlueText;
	public Text YellowText;

	private int rayMask = 1;

	// Use this for initialization
	void Start ()
	{
		control = GetComponentInParent<PlatformerCharacter2D> ();
		startingPosition = transform.localPosition;
		UI = FindObjectOfType<ChangeImageOnPress> ();
		rayMask |= 1 << LayerMask.NameToLayer ("Player");
		rayMask |= 1 << LayerMask.NameToLayer ("Bullet");
	}
	
	// Update is called once per frame
	void Update ()
	{
		RedText.text = (int)RedAmmo + "";
		BlueText.text = (int)BlueAmmo + "";
		YellowText.text = (int)YellowAmmo + "";

		if (CheckAlone ()) {
			BlueAmmo += 0.5f;
			if (BlueAmmo > 100) {
				BlueAmmo = 100;
			}
		}

		Vector3 diff = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		diff.Normalize ();

		float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg + 90.0f;
		if (!control.m_FacingRight) {
			rot_z += 180;
		}
		transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 90);	
	
		if (Input.GetMouseButton (0)) {
			firing = true;
			int facing = -1;
			timer += Time.deltaTime;

			if (timer > 0.1f && !Laser.activeSelf && firing) {
				RedAmmo += Time.deltaTime * 2 * timer;
				if (RedAmmo > 100) {
					RedAmmo = 100;
				}
			}
			if (!control.m_FacingRight) {
				facing = 1;
			}
			if (UI.gunColor == GunColor.Red) {
				if (RedAmmo > 0) {
					RedAmmo -= 0.25f;
					if (!Laser.activeSelf) {
						Laser.SetActive (true);
					}
					transform.localPosition = startingPosition + (transform.rotation * new Vector3 (0.15f * Mathf.Sin (Time.time * 9), 0.06f * Mathf.Cos (Time.time * 10), 0.0f));
				} else {
					if (Laser.activeSelf) {
						Laser.SetActive (false);
					}
				}
			} else if (UI.gunColor == GunColor.Blue) {
				if (BlueAmmo > 0) {
					if (Laser.activeSelf) {
						Laser.SetActive (false);
					}
					counter++;
					if (timer % 0.1 < 0.05) {
						BlueAmmo -= 0.4f;
						GameObject newBullet = Instantiate (Tear, Barrel.transform.position, Quaternion.Euler (facing * transform.rotation.eulerAngles));
						if (counter % 2 == 0) {
							newBullet.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (-0.2f - 0.2f * Random.value, 1.0f) * 600 * facing);
						} else {
							newBullet.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * new Vector2 (0.2f + 0.2f * Random.value, -1.0f) * 600 * facing);
						}
					}
				} else {
					firing = false;
					timer = 0;
				}
			} else if (UI.gunColor == GunColor.Yellow) {
				if (YellowAmmo > 0) {
					if (Laser.activeSelf) {
						Laser.SetActive (false);
					}
					if (timer % 0.1 < 0.05) {
						YellowAmmo -= 0.5f;
						Instantiate (Frustration, Barrel.transform.position, Quaternion.Euler (0, 0, Random.Range (0, 360)));
					}
				} else {
					timer = 0;
					firing = false;
				}
			}
			control.m_Rigidbody2D.AddForce (transform.rotation * new Vector2 (1.0f, 0.0f) * 30 * facing);
		} else {
			timer = 0;
			firing = false;
			if (Laser.activeSelf) {
				Laser.SetActive (false);
			}
		}
	}

	bool CheckAlone ()
	{
		if (firing) {
			return false;
		}
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			RaycastHit2D hit = Physics2D.Raycast (transform.position, enemy.transform.position - transform.position, 100f, rayMask);
			Debug.DrawRay (transform.position, enemy.transform.position - transform.position);
			if (hit) {
				if (hit.collider.tag == "Enemy") {
					return false;
				}
			}
		}
		return true;
	}

	public void Miss() {
		YellowAmmo += 0.2f;
		if (YellowAmmo > 100) {
			YellowAmmo = 100;
		}
	}

	public void Death(){
		BlueAmmo += 5;
		if (BlueAmmo > 100) {
			BlueAmmo = 100;
		}
	}
}
