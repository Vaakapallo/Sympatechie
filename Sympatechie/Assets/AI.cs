using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	public float speed = 0.1f;
	private StoreStuff store;
	private SpriteRenderer sprite;
	private GunColor primedForExplosion = GunColor.None;
	private float timer = 0f;
	private Color storedColor;

	// Use this for initialization
	void Start () {
		store = FindObjectOfType<StoreStuff> ();
		sprite = GetComponent<SpriteRenderer> ();
		StartCoroutine (ChangeDirection());	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		transform.Translate (new Vector3 (speed, 0.0f, 0.0f));
		if (primedForExplosion == GunColor.None) {
			if (sprite.color.r > 2f && sprite.color.g < 0.5) {
				primedForExplosion = GunColor.Red;
				storedColor = sprite.color;
				StartCoroutine (Flash ());
			}
			if (sprite.color.b > 2f) {
				primedForExplosion = GunColor.Blue;
				storedColor = sprite.color;
				StartCoroutine (Flash ());
			}
			if (sprite.color.g > 2f && sprite.color.r > 1.5f) {
				primedForExplosion = GunColor.Yellow;
				storedColor = sprite.color;
				StartCoroutine (Flash ());
			}
		}
	}

	IEnumerator Flash(){
		while (true) {
			sprite.color = Color.white;
			yield return new WaitForSeconds (0.1f);
			sprite.color = storedColor;
			yield return new WaitForSeconds (0.3f);
		}
	}

	IEnumerator ChangeDirection(){
		while (true) {
			yield return new WaitForSeconds (Random.Range (5, 15));
			speed = -speed;
		}
	}

	public void AddColor(GunColor color){
		if (primedForExplosion == GunColor.None) {
			Color ecolor = sprite.color;
			if (color == GunColor.Yellow) {
				sprite.color = new Color (ecolor.r + 0.06f, ecolor.g + 0.06f, ecolor.b - 0.06f);
			} else if (color == GunColor.Blue) {
				sprite.color = new Color (ecolor.r - 0.06f, ecolor.g - 0.06f, ecolor.b + 0.06f);
			} else if (color == GunColor.Red) {
				sprite.color = new Color (ecolor.r + 0.02f, ecolor.g - 0.02f, ecolor.b - 0.02f);
			}
		} else {
			if (primedForExplosion != color) {
				if (primedForExplosion == GunColor.Red) {
					store.CreateLaserExplosion (transform);
				} else if (primedForExplosion == GunColor.Blue) {
					store.BlueExplosion (transform);
				} else if (primedForExplosion == GunColor.Yellow){
					store.YellowExplosion (transform);
				}
				//store.CreateExplosion (transform);
				Destroy (gameObject);
				return;
			} 
		}
	}
}
