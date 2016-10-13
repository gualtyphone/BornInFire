using UnityEngine;
using System.Collections;

public class OrbFollow : MonoBehaviour {

	public bool collected;
	public GameObject player;
	public Transform light;
	private bool lightRemoved;

	public bool collectable;
	public GameObject gotoTarget;

	public AudioSource wisp;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		collected = false;
		collectable = true;
		lightRemoved = false;
		gotoTarget = player;
		wisp = GameObject.Find ("WispSource").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.transform.position;
		playerPos.x -= 1;
		if (collected == true) {
			transform.position = Vector3.MoveTowards(transform.position, playerPos, 0.3f);
		}
		if (collectable == false){
			transform.position = Vector3.MoveTowards (transform.position, gotoTarget.transform.position, 0.3f);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && collectable == true) {
			collected = true;
			collectable = false;

			player.GetComponent<PlayerManager>().health += 30.0f;

			wisp.Play ();

			if (lightRemoved == false)
			{
				light = this.transform;
				light.GetComponentInChildren<DynamicLight>().lightRadius = 0;
				//light = transform.FindChild("2DLight - NOT PLAYER");
				//Destroy(light.gameObject);
				lightRemoved = true;
			}
		}
	}

	public void goTo(GameObject obj)
	{
		collectable = false;
		gotoTarget = obj;
	}
}
