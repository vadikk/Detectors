using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingManager : MonoBehaviour {

	public static WingManager instance;

	public WingMove[] wingMove;
	public float minAnglePower;
	public float maxAnglePower;
	public float minAngle = 0f;
	public float maxAngle = 100f;
	public bool animate;
	public float wingMoveSpeed;

	public float angle;
	public float wingsInterval;


	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		wingsInterval += Time.deltaTime;
		if (GameManagerSPE.instance.deviceOn) {
			if (wingsInterval > 0.5f) {
				angle = Random.Range (WingManager.instance.minAnglePower, WingManager.instance.maxAnglePower);

				angle = Mathf.Clamp (angle, WingManager.instance.minAngle, WingManager.instance.maxAngle);

				wingMove [0].SetAngle (angle, WingManager.instance.animate);
				wingMove [1].SetAngle (angle, WingManager.instance.animate);
				wingsInterval = 0;
			}
		} 
	}

	public void ResetWing(){
		for (int i = 0; i < wingMove.Length; i++) {
			wingMove [i].ResetPosWing ();
		}
	}
}
