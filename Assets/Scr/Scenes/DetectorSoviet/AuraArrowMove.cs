using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraArrowMove : ArrowAura {

	public static AuraArrowMove instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	public override void Update () {
		if (GameManagerSoviet.instance.deviceMainOn) {
			_arrowAURAPower += Random.Range (minAURAPower, maxAURAPower);
			_arrowAURAPower -= gravityAURA;

			_arrowAURAPower = Mathf.Clamp (_arrowAURAPower, maxAURAArrow, minAURAArrow);
			transform.localEulerAngles = new Vector3 (0, 0, _arrowAURAPower);
		}
	}
}
