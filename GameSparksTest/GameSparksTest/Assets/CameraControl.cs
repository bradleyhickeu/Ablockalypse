using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float speed = 5.0f;
		float dz = Input.GetAxis ("Mouse ScrollWheel");
		float zoom = GetComponent<Camera> ().orthographicSize; 
		//Debug.Log (dz);
		//Debug.Log ("zoom = "+ zoom);
		if (zoom >= 3 && dz > 0) {
			GetComponent<Camera> ().orthographicSize -= dz * speed;
		}
		if (zoom <= 10 && dz < 0) {
			GetComponent<Camera> ().orthographicSize -= dz * speed;
		}
		Transform topLevel = transform.parent;

		if (Input.GetKey (KeyCode.LeftArrow)) {
			topLevel.Translate (speed * Time.deltaTime, 0, speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			topLevel.Translate (-speed * Time.deltaTime, 0, -speed * Time.deltaTime);
		}
	}
}
