using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSPE : MonoBehaviour {

	public static GameManagerSPE instance;

	public float bulbTurnOnOffSpeed;
	public float bulbTurnDelay;
	public bool deviceOn = false;
	public DiodManager diod1;
	public DiodManager diod2;
	public GameObject[] dots = new GameObject[3];

	public GameObject yellowBulb;
	public GameObject blueBulb;
	public Sprite yellowSpriteOn;
	public Sprite blueSpriteOn;
	public Sprite yellowSpriteOff;
	public Sprite blueSpriteOff;
	public GameObject switchSensorBtn1;
	public GameObject switchSensorBtn2;
	public Sprite switchRedBtnOn;
	public Sprite switchRedBtnOff;

	private IEnumerator coroutine1;
	private float rabdomX;
	private float rabdomY;
	private bool deviceMode = false;
	private int sensorType;
	private bool switchSensorMode1 = false;
	private bool switchSensorMode2 = false;

	// Use this for initialization

	void Awake(){
		instance = this;
		coroutine1 = ShowRandomDots ();
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		rabdomX = Random.Range (-0.669f, 0.714f);
		rabdomY = Random.Range (1.1f, 2.226f);
	}

	public void On_Off(){
		deviceOn = !deviceOn;

		if (deviceOn) {
			diod1.SetState (2);
			diod2.SetState (2);
			StartShowPoints ();
		
		} else {
			diod1.SetState (0);
			diod2.SetState (0);
			ResetDots ();
			WingManager.instance.ResetWing ();
		}
	}

	void StartShowPoints(){
		StartCoroutine (StartShowPoint ());
	}

	IEnumerator ShowRandomDots(){
		while (true) {
			for (int i = 0; i < dots.Length; i++) {
				ShowPoint turn = dots[i].GetComponent<ShowPoint> ();
				turn.TurnOnPoint ();
				dots [i].transform.position = new Vector2 (rabdomX, rabdomY);
				yield return new WaitForSeconds (1f);
				turn.TurnOffPoint ();
			}
		}
	}

	IEnumerator StartShowPoint(){
			for (int j = 0; j < dots.Length; j++) {
				dots [j].transform.position = new Vector3 (0, 1.7f, 0);
				ShowPoint turn = dots [j].GetComponent<ShowPoint> ();
				turn.TurnOnPoint ();
				yield return new WaitForSeconds (0.3f);
				turn.TurnOffPoint ();
			}
			StartCoroutine (coroutine1);
	}

	private void ResetDots(){

		for (int i = 0; i < dots.Length; i++) {
			ShowPoint turn = dots[i].GetComponent<ShowPoint> ();
			turn.TurnOffPoint ();
		}
		StopCoroutine (coroutine1);
	}

	public void Button_Segest(){
		
	}
	public void Button_Share(){

	}
	public void Button_GoToShop(){

	}
	public void Button_SwitchMode(){
		deviceMode = !deviceMode;
		if (!deviceMode) {
			yellowBulb.GetComponent<SpriteRenderer> ().sprite = yellowSpriteOn;
			blueBulb.GetComponent<SpriteRenderer> ().sprite = blueSpriteOff;
		} else {
			blueBulb.GetComponent<SpriteRenderer> ().sprite = blueSpriteOn;
			yellowBulb.GetComponent<SpriteRenderer> ().sprite = yellowSpriteOff;
		}

	}

	public void Button_SwitchSensor1(){
		switchSensorMode1 = !switchSensorMode1;

		if (switchSensorMode1) {
			sensorType = 1;
			switchSensorBtn1.GetComponent<SpriteRenderer> ().sprite = switchRedBtnOn;
		} else {
			switchSensorBtn1.GetComponent<SpriteRenderer> ().sprite = switchRedBtnOff;
		}
	}

	public void Button_SwitchSensor2(){
		switchSensorMode2 = !switchSensorMode2;

		if (switchSensorMode2) {
			sensorType = 2;
			switchSensorBtn2.GetComponent<SpriteRenderer> ().sprite = switchRedBtnOn;
		} else {
			switchSensorBtn2.GetComponent<SpriteRenderer> ().sprite = switchRedBtnOff;
		}
	}
}
