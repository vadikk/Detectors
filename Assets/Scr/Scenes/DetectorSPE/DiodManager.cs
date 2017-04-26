using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiodManager : MonoBehaviour {


	public TurnOnDiod[] diodsShow;

	private float delay = 0.3f;

	private IEnumerator coroutine_2;
	private IEnumerator coroutine_1;

	void Awake(){
	}

	// Use this for initialization
	void Start () {
		coroutine_2 = ShowState_2 ();
		coroutine_1 = ShowState_1 ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetState(int state){
		switch (state) {
		case 0:
			ResetShowDiods ();
			break;
		case 1:
				StartCoroutine (coroutine_1);
			break;

		case 2:
			coroutine_2 = ShowState_2 ();
			StartCoroutine (coroutine_2);
			break;
		}
	}

	IEnumerator ShowState_2(){
		for (int j = 0; j < 3; j++) {
			for (int i = 0; i < diodsShow.Length; i++) {
				diodsShow [i].ShowLight ();
				//yield return new WaitForSeconds (delay);
			}
			for (int i = 0; i < diodsShow.Length; i++) {
				diodsShow [i].TurnOffLight ();
				//yield return new WaitForSeconds (delay);
			}
			yield return new WaitForSeconds (delay);
		}
		SetState (1);
	}

	IEnumerator ShowState_1(){
		while (true) {
			for (int i = 0; i < diodsShow.Length; i++) {
				diodsShow [i].ShowLight ();
				yield return new WaitForSeconds (delay * GameManagerSPE.instance.bulbTurnDelay);
				diodsShow [i].TurnOffLight ();
				yield return new WaitForSeconds (delay * GameManagerSPE.instance.bulbTurnOnOffSpeed);
			}
		}
	}

	public void ResetShowDiods(){
		StopCoroutine (coroutine_1);
		StopCoroutine (coroutine_2);
		for (int i = 0; i < diodsShow.Length; i++) {
			diodsShow [i].TurnOffLight ();
		}
	}

}
