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

	// Use this for initialization
	void Start () {
		image = GetComponentsInChildren<Image> ();
		sprites1 = Resources.LoadAll<Sprite> ("Sprites/UI/SlotOne");
		sprites2 = Resources.LoadAll<Sprite> ("Sprites/UI/SlotTwo");
		sprites3 = Resources.LoadAll<Sprite> ("Sprites/UI/SlotThree");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			image[0].sprite = sprites1 [++i % sprites1.Length];
		} if (Input.GetKeyDown (KeyCode.Alpha2)){
			image[1].sprite = sprites2[++i % sprites2.Length];
		} if (Input.GetKeyDown (KeyCode.Alpha3)){
			image[2].sprite = sprites3[++i % sprites3.Length];
		}
	}
}
