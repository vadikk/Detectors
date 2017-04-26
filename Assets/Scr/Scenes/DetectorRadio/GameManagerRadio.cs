using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRadio : MonoBehaviour {

	public static GameManagerRadio instance;

	public bool deviceOn = false;
	public AudioClip clip;
	public DiodShow [] diods;

	private AudioSource audioS;
	private IEnumerator coroutine1;

	void Awake(){
		instance = this;
		coroutine1 = TurnOnDiod ();
	}

	// Use this for initialization
	void Start () {
		audioS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Button_OnOff(){
		deviceOn = !deviceOn;
		if (deviceOn) {
			audioS.PlayOneShot (clip);
			StartShowDiods ();
		} else {
			StopCoroutine (coroutine1);
			ResetDiods ();
			ArrowMove.instance.ResetPosition ();
		}
	}

	void StartShowDiods(){
		StartCoroutine (coroutine1);;
	} 

	IEnumerator TurnOnDiod(){
		while (true) {
			for (int i = 0; i < diods.Length; i++) {
				diods [i].ShowLight ();
				yield return new WaitForSeconds (2f);
				diods [i].TurnOffLight ();
				yield return new WaitForSeconds (2f);
			}
		}
	}
	void ResetDiods(){
		for (int i = 0; i < diods.Length; i++) {
			diods [i].TurnOffLight ();
		}
	}

	public void Button_Sugest(){
		
	}
	public void Button_Share(){
		
	}
	public void Button_GoToShop(){

	}
}
