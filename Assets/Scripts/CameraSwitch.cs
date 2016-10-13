using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	
	public Camera camera;
	public GameObject player;
	public GameObject ritualWaypoint;
	public bool zoomOut;

	public AudioSource heal;


	// Use this for initialization
	void Start () {
		zoomOut = true;
		heal = GameObject.Find ("HealSource").GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (zoomOut == true && camera.orthographicSize < 35) {
			camera.orthographicSize += 1;
		}
		if (zoomOut == false && camera.orthographicSize > 5) {
			camera.orthographicSize -= 1;
		}
	}

	void OnTriggerEnter() {
		zoomOut = true;
		heal.Play ();
	}

	void OnTriggerExit() {
		zoomOut = false;
	}
}
