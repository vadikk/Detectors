using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour {

	public static ArrowMove instance;
	public AudioClip clip2;
	public float maxX, minX;

	private AudioSource audioS;
	private float arrowInterval;
	private float randomPos;
	private Vector3 pos;

	void Awake(){
		instance = this;
		pos = transform.position;
	}
	// Use this for initialization
	void Start () {
		audioS = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManagerRadio.instance.deviceOn) {
			audioS.PlayOneShot (clip2);
		} else {
			audioS.Stop ();
		}

		arrowInterval += Time.deltaTime;
		if (GameManagerRadio.instance.deviceOn) {
			if (arrowInterval > 0.5f) {
				randomPos = Random.Range (minX, maxX);

				randomPos = Mathf.Clamp (randomPos, -1.85f, 1.78f);
				arrowInterval = 0;
			}
			iTween.MoveTo (gameObject, iTween.Hash ("x", randomPos, "speed", 2, "easetype", iTween.EaseType.easeOutQuint));
		} 
	}

	public void ResetPosition(){
		iTween.MoveTo (gameObject, iTween.Hash ("x", pos.x, "speed", 2, "easetype", iTween.EaseType.easeOutQuint));
	}

}
