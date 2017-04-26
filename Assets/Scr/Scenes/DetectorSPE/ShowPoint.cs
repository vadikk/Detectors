using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPoint : MonoBehaviour {

	private Animator anim;
	public bool isOn = false;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnOnPoint(){
		if (!isOn) {
			anim.SetTrigger ("On");
			isOn = true;
		}
	}

	public void TurnOffPoint(){
		if (isOn) {
			anim.SetTrigger ("Off");
			isOn = false;
		}
	}
}
