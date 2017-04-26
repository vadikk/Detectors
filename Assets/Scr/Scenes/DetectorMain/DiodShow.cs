using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiodShow : MonoBehaviour {

	private Animator anim;
	public bool isOn = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ShowLight(){
		if (!isOn) {
			anim.SetTrigger ("On");
			isOn = true;
		}
		//anim.speed = Diods.instance.bulbSequenceSpeed;
	}

	public void TurnOffLight(){
		if (isOn) {
			anim.SetTrigger ("Off");
			isOn = false;
		}

	}
}
