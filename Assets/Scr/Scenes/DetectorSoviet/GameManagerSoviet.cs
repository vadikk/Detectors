using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManagerSoviet : GameManager {

	public static GameManagerSoviet instance;

	private AudioSource audioS2;

	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		audioS2 = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void DeviceOn ()
	{
		deviceMainOn = !deviceMainOn;

		if (deviceMainOn) {
			ButtonOn_Off.instance.GetSpriteOn ();
			audioS2.PlayOneShot (soundEffectOn);
			DiodManagerSoviet.instance.Starting ();
		} else {
			ButtonOn_Off.instance.GetSpriteOff ();
			audioS2.PlayOneShot (soundEffectOff);
			AuraArrowMove.instance.ResetAuraArrow ();
			ArrowStalkerMove.instance.ResetMainArrow ();
			DiodManagerSoviet.instance.ResetTurnOnDiods ();
		}
	}

	public void Button_SetMod(){
		
	}

	public void Button_Sugest(){
		
	}

	public void Button_Share(){
		
	}

	public void Button_GoToShop(){
		
	}

}
