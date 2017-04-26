using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMove : MonoBehaviour {

	private float baseAngle = 0f;
	public float min, max;
	public AudioClip clip;

	private float angle;
	private AudioSource audioS;

	// Use this for initialization
	void Start () {
		audioS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.touchCount > 0) {
			/*Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began) {
				Vector3 pos = Camera.main.ScreenToWorldPoint (transform.position);
				Vector3 pos2 = touch.deltaPosition;
				pos = pos2 - pos;
				pos.z = 0f;
				baseAngle = Mathf.Atan2 (pos.y, pos.x) * Mathf.Rad2Deg;
				print (pos);
			}
			if (touch.phase == TouchPhase.Moved) {
				Vector3 pos = Camera.main.ScreenToWorldPoint (transform.position);
				Vector3 pos2 = touch.deltaPosition;
				pos = pos2 - pos;
				pos.z = 0f;
				angle = Mathf.Atan2 (pos2.y, pos2.x) * Mathf.Rad2Deg * baseAngle;
				print (pos);
				transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			}
		
		}*/


	}

	void OnMouseDown(){
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		pos = Input.mousePosition - pos;
		baseAngle = Mathf.Atan2 (pos.y, pos.x) * Mathf.Rad2Deg;
		baseAngle -= Mathf.Atan2 (transform.right.y, transform.right.x) * Mathf.Rad2Deg;
		//print (baseAngle);
	}

	void OnMouseDrag(){
		Vector3 pos2 = Camera.main.WorldToScreenPoint (transform.position);
		pos2 = Input.mousePosition - pos2;
		angle = Mathf.Atan2 (pos2.y, pos2.x) * Mathf.Rad2Deg - baseAngle;
		float angle2 = Mathf.Clamp (angle, -295, 0);
		SetFrequency (angle2);
		//print ("angle" + angle);
	}
		
	void SetFrequency(float value){
		//value = Mathf.Clamp(value,-295,0);

		transform.rotation = Quaternion.AngleAxis (value, Vector3.forward);
	}
		

}
