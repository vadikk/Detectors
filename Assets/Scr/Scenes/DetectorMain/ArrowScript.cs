using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

	public static ArrowScript instance;

	public float _arrowMainPower;
	public float minMainArrow = 0f;
	public float maxMainArrow = -76f;
	public AudioSource audioS;
	public float currentInterval = 0f;

	public float minMainPower;
	public float maxMainPower;
	public float gravityMain;
	public int numberDiodTurnOn = 0;
	public AudioClip clip;
	public float beepSpeed = 3f;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		audioS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (GameManager.instance.deviceMainOn) {
			_arrowMainPower += Random.Range (minMainPower, maxMainPower);
			_arrowMainPower -= gravityMain;


			for (int i = 0; i < 5; i++) {
				if (_arrowMainPower < i * maxMainArrow / 5 && _arrowMainPower > (i + 1) * maxMainArrow / 5) {
					numberDiodTurnOn = i;
					Diods.instance.TurnOnDiods (numberDiodTurnOn);
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
	}

	public void ResetMainArrow(){
		transform.localEulerAngles = new Vector3 (0, 0, 0);
	}

}
