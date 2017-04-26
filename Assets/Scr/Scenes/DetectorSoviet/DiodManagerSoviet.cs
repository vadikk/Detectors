using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiodManagerSoviet : Diods {

	public static DiodManagerSoviet instance;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		if (GameManagerSoviet.instance.deviceMainOn) {
			audioS2.PlayOneShot (BGSound);
		} else {
			audioS2.Stop ();
		}
	}
		

	public override IEnumerator StartingSequence(){
		for (int i = 0; i < 2; i++) {
			for (int j = 0; j < diodshow.Length; j++) {
				diodshow [j].ShowLight ();
				yield return new WaitForSeconds (delay * bulbSequenceSpeed);
			}
			for (int k = 0; k < diodshow.Length; k++) {
				diodshow [k].TurnOffLight ();
				yield return new WaitForSeconds (delay * bulbSequenceSpeed);

			}
			yield return new WaitForSeconds (delay * bulbSequenceSpeed);
		}
	}
}
