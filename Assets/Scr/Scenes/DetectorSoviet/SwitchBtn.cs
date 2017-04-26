using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchBtn : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

	public static SwitchBtn instance;

	public AudioClip beep;
	public AudioClip beep1;
	public AudioClip beep2;
	public AudioClip beep3;
	public AudioClip switchsound1;
	public AudioClip switchsound2;

	private RectTransform btn;
	private AudioSource audioS;
	private bool change1 = false;
	private bool change2 = false;
	private bool change3 = false;

	private float posY1;
	private float posY2;
	private float posY3;
	private float posY4;
	private float posY5;

	void Awake(){
		instance = this;
		SetScreenSettings ();
	}

	// Use this for initialization
	void Start () {
		audioS = GetComponent<AudioSource> ();
		btn = GetComponent<RectTransform> ();

		GetCurrentSound ();
	}

	// Update is called once per frame
	void Update () {
		SetScreenSettings ();
		GetCurrentSound ();

	}

	void SetScreenSettings(){
		Vector3 pos = new Vector3 (Screen.width, Screen.height);
		if (pos.x == 480f && pos.y == 800f) {
			posY1 = 180f;
			posY2 = 206f;
			posY3 = 144f;
			posY4 = 120f;
			posY5 = 160f;
		}
		if (pos.x == 720f && pos.y == 1280f) {
			posY1 = 290f; 
			posY2 = 326f; 
			posY3 = 244f; 
			posY4 = 195f; 
			posY5 = 265f; 
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{

	}

	public void OnDrag(PointerEventData eventData)
	{
		var currPos = btn.position;
		currPos.y += eventData.delta.y;
		currPos.y = Mathf.Clamp (currPos.y, posY4, posY2);
		btn.position = currPos;
	}


	public void OnEndDrag(PointerEventData eventData)
	{
		if (btn.position.y > posY1 && btn.position.y < posY2 || btn.position.y == posY2) {
			change1 = true;
			change2 = false;
			ArrowStalkerMove.instance.resetArrow = true;
			iTween.MoveTo (gameObject, iTween.Hash ("y", posY2, "speed", 100f, "easetype", iTween.EaseType.easeOutQuint));
		} else if (btn.position.y < posY1 && btn.position.y > posY3) {
			change1 = false;
			change3 = false;
			change2 = true;
			ArrowStalkerMove.instance.resetArrow = true;
			iTween.MoveTo (gameObject, iTween.Hash ("y", posY5, "speed", 100f, "easetype", iTween.EaseType.easeOutQuint));
		}else if (btn.position.y < posY3 && btn.position.y > posY4 || btn.position.y == posY4) {
			change3 = true;
			change1 = false;
			ArrowStalkerMove.instance.resetArrow = true;
			iTween.MoveTo (gameObject, iTween.Hash ("y", posY4, "speed", 100f, "easetype", iTween.EaseType.easeOutQuint));
		}
	}

	void GetCurrentSound(){
		if (GameManagerSoviet.instance.deviceMainOn) {
			if (btn.position.y > posY1 && btn.position.y < posY2) {
				beep = beep1;
			} else if (btn.position.y < posY1 && btn.position.y > posY3) {
				beep = beep2;
			} else if (btn.position.y < posY3 && btn.position.y > posY4) {
				beep = beep3;
			}
			if (change1) {
				audioS.PlayOneShot (switchsound1);
				change1 = false;
			} else if (change2) {
				audioS.PlayOneShot (switchsound2);
				change2 = false;
			} else if (change3) {
				audioS.PlayOneShot (switchsound1);
				change3 = false;
			}
		}
	}

}
	
