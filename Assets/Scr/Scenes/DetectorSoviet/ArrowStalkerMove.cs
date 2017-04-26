using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStalkerMove : ArrowScript {

	public static ArrowStalkerMove instance;

	public bool resetArrow = false;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		clip = SwitchBtn.instance.beep;
	}
	
	// Update is called once per frame
	public override void Update () {
		clip = SwitchBtn.instance.beep;
		if (GameManagerSoviet.instance.deviceMainOn && !resetArrow) {
			_arrowMainPower += Random.Range (minMainPower, maxMainPower);
			_arrowMainPower -= gravityMain;

			for (int i = 0; i < 9; i++) {
				if (_arrowMainPower < i * maxMainArrow / 9 && _arrowMainPower > (i + 1) * maxMainArrow / 9) {
					numberDiodTurnOn = i;
					DiodManagerSoviet.instance.TurnOnDiods (numberDiodTurnOn);
				}
			}
			_arrowMainPower = Mathf.Clamp (_arrowMainPower, maxMainArrow, minMainArrow);
			transform.localEulerAngles = new Vector3 (0, 0, _arrowMainPower);

			currentInterval += Time.deltaTime;
			if (currentInterval > beepSpeed) {
				currentInterval = 0f;
				audioS.PlayOneShot (clip);
			}

		}
		if (resetArrow) {
			StartCoroutine (ResetArrow ());
		}	

	}

	IEnumerator ResetArrow(){
		ResetMainArrow ();
		DiodManagerSoviet.instance.ResetTurnOnDiods ();
		yield return new WaitForSeconds (0.7f);
		resetArrow = false;
		_arrowMainPower = 0;
	}
}
