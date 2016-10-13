using UnityEngine;
using System.Collections;

public class HowtoPlayScript : MonoBehaviour {
    
	public GameObject cam;
	public GameObject HowToPlay;
	public GameObject MainMenu;
	public bool MoveCamera;

	public void Start(){
		MoveCamera = false;
	}

	// Update is called once per frame
	public void Update (){
		if (MoveCamera == true) {
			cam.transform.position = Vector3.MoveTowards (cam.transform.position, HowToPlay.transform.position, 3f);
		} else {
			cam.transform.position = Vector3.MoveTowards (cam.transform.position, MainMenu.transform.position, 3f);
		}
	}
    public void LoadLevelNow()
    {
		MoveCamera = true;
    }

	public void MenuScreen()
	{
		MoveCamera = false;
	}
}
