using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAura : MonoBehaviour {

	public static ArrowAura instance;

	public float _arrowAURAPower;
	public float minAURAArrow = 100f;
	public float maxAURAArrow = -100f;

	public float minAURAPower;
	public float maxAURAPower;
	public float gravityAURA;
	public bool deviceAURAOn = false;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (GameManager.instance.deviceMainOn && deviceAURAOn) {
			_arrowAURAPower += Random.Range (minAURAPower, maxAURAPower);
			_arrowAURAPower -= gravityAURA;

			_arrowAURAPower = Mathf.Clamp (_arrowAURAPower, maxAURAArrow, minAURAArrow);
			transform.localEulerAngles = new Vector3 (0, 0, _arrowAURAPower);
		}
	}

	public void ResetAuraArrow(){
		transform.localEulerAngles = new Vector3 (0, 0, 0);
	}
}
