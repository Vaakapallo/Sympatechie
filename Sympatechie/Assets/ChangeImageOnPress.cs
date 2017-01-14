using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageOnPress : MonoBehaviour {

	private Image[] image;
	private Sprite[] sprites1;
	private Sprite[] sprites2;
	private Sprite[] sprites3;
	private int i = 0;
	public GunColor gunColor = GunColor.Red;

	// Use this for initialization
	void Start () {
		image = GetComponentsInChildren<Image> ();
		sprites1 = Resources.LoadAll<Sprite> ("Sprites/UI/SlotOne");
		sprites2 = Resources.LoadAll<Sprite> ("Sprites/UI/SlotTwo");
		sprites3 = Resources.LoadAll<Sprite> ("Sprites/UI/SlotThree");
		image[0].sprite = sprites1 [++i % sprites1.Length];
		gunColor = GunColor.Red;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			image[0].sprite = sprites1 [1];
			image[1].sprite = sprites2 [0];
			image[2].sprite = sprites3 [0];

			gunColor = GunColor.Red;
		} if (Input.GetKeyDown (KeyCode.Alpha2)){
			image[0].sprite = sprites1 [0];
			image[1].sprite = sprites2 [1];
			image[2].sprite = sprites3 [0];
			gunColor = GunColor.Blue;
		} if (Input.GetKeyDown (KeyCode.Alpha3)){
			image[0].sprite = sprites1 [0];
			image[1].sprite = sprites2 [0];
			image[2].sprite = sprites3 [1];
			gunColor = GunColor.Yellow;
		}
	}
}
