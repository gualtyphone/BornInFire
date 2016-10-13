using UnityEngine;
using System.Collections;

public class EscMenuScript : MonoBehaviour {

	public GameObject EscMenu;
	public bool menuOpen;

	// Use this for initialization
	void Start () {
		menuOpen = false;
		EscMenu.SetActive (menuOpen);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape) == true) {
			if (menuOpen)
			{
				menuOpen = false;
			}
			else
			{
				menuOpen = true;
			}
		}

		if (menuOpen == true) {
			EscMenu.SetActive(true);
			Time.timeScale = 0;
		}
		else {
			EscMenu.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void ExitMenu(){
		menuOpen = false;
	}
}