using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool deviceMainOn = false;
	public AudioClip soundEffectOn;
	public AudioClip soundEffectOff;

	private AudioSource audioS1;

	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		audioS1 = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void DeviceOn (){
		deviceMainOn = !deviceMainOn;

		if (deviceMainOn) {
			ArrowAura.instance.deviceAURAOn = true;
			ButtonOn_Off.instance.GetSpriteOn ();
			Diods.instance.Starting ();
			audioS1.PlayOneShot (soundEffectOn);

		} else {
			ArrowAura.instance.deviceAURAOn = false;
			ButtonOn_Off.instance.GetSpriteOff ();
			audioS1.PlayOneShot (soundEffectOff);
			ArrowScript.instance.ResetMainArrow ();
			ArrowAura.instance.ResetAuraArrow ();
			Diods.instance.ResetTurnOnDiods ();
		}


	}

	public void Button_Sugest(){

	}

	public void Button_Share(){

	}

	public void Button_GoToShop(){

	}

	public void Button_AuraOnOff(){

	}


}
