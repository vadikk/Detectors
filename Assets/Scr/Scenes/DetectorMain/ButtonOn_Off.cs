using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOn_Off : MonoBehaviour {

	public static ButtonOn_Off instance;

	public Sprite spriteOn;
	public Sprite spriteOff;

	private Button btn;

	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetSpriteOn(){
		btn.image.sprite = spriteOn;
	}

	public void GetSpriteOff(){
		btn.image.sprite = spriteOff;
	}

}
