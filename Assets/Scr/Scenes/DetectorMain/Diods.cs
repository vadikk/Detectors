using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diods : MonoBehaviour {

	public static Diods instance;
	public float bulbSequenceSpeed;
	public AudioClip BGSound;
	public AudioSource audioS2;

	public DiodShow[] diodshow;
	public float delay = 0.2f;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (GameManager.instance.deviceMainOn) {
			audioS2.PlayOneShot (BGSound);
		} else {
			audioS2.Stop ();
		}
			
	}

	public void Starting(){
		StartCoroutine (StartingSequence ());
	}

	public virtual IEnumerator StartingSequence(){
		for (int j = 0; j < 3; j++) {
			for (int i = 0; i < diodshow.Length; i++) {
				diodshow [i].ShowLight ();
				yield return new WaitForSeconds (delay * bulbSequenceSpeed);
			}
			for (int i = 0; i < diodshow.Length; i++) {
				diodshow [i].TurnOffLight ();

			}
			yield return new WaitForSeconds (delay *bulbSequenceSpeed);
		}
	}

	public void TurnOnDiods(int lastindex){

		for (int i = 0; i < diodshow.Length; i++) {
			if(i<=lastindex)
				diodshow [i].ShowLight ();
			else
				diodshow [i].TurnOffLight ();

		}
	}

	public void ResetTurnOnDiods(){
		for (int i = 0; i < diodshow.Length; i++) {
			diodshow [i].TurnOffLight ();
		}
	}

}
