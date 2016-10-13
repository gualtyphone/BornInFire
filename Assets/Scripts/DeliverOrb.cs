using UnityEngine;
using System.Collections;

public class DeliverOrb : MonoBehaviour {

	public int orbsCollected;
	public GameObject orb;
	public GameObject player;

	public GameObject finalPosition;

	public GameObject winScreen;



	// Use this for initialization
	void Start () {
		orbsCollected = 0;
		player = GameObject.Find ("Player");
		finalPosition = GameObject.Find ("FinalGoal");
	}
	
	// Update is called once per frame
	void Update () {
		if (orbsCollected == 5) {
		
			winScreen.SetActive(true);
			if (player.transform.position != finalPosition.transform.position)
			{
				player.transform.position = Vector3.MoveTowards(player.transform.position,finalPosition.transform.position, 0.6f);
			}
			else
			{
				Time.timeScale = 0;
			}


		
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Orb") {
			orb = other.transform.parent.gameObject;
			orb.GetComponent<OrbFollow>().collected = false;
			orb.GetComponent<OrbFollow>().collectable = false;

			GameObject moveTarget = null;

			if (orbsCollected == 0)
				moveTarget = GameObject.Find ("Waypoint000");
			if (orbsCollected == 1)
				moveTarget = GameObject.Find ("Waypoint001");
			if (orbsCollected == 2)
				moveTarget = GameObject.Find ("Waypoint002");
			if (orbsCollected == 3)
				moveTarget = GameObject.Find ("Waypoint003");
			if (orbsCollected == 4)
				moveTarget = GameObject.Find ("Waypoint004");

			orbsCollected += 1;

			orb.GetComponent<OrbFollow>().goTo(moveTarget);
		}
		if (other.gameObject.tag == "Player"&& player.GetComponent<PlayerManager>().health < 100) {

			player.GetComponent<PlayerManager>().health = 100.0f;
		}
	}
}
