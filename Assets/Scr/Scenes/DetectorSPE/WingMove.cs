using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingMove : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetAngle(float angle, bool animate){
		if (animate) {
			iTween.RotateTo(this.gameObject,iTween.Hash("z", angle,"speed", WingManager.instance.wingMoveSpeed,"easetype", iTween.EaseType.easeOutQuint));
		} else {
			transform.localEulerAngles = new Vector3 (0, 0, angle);
		}
	}

	public void ResetPosWing(){
		//transform.localEulerAngles = new Vector3 (0, 0, 0);
		iTween.RotateTo(this.gameObject,iTween.Hash("z", 0,"speed", WingManager.instance.wingMoveSpeed,"easetype", iTween.EaseType.easeOutQuint));
	}
}
