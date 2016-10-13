using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public float health;
	public GameObject shadowMaker;

	public AudioSource collide;
	public AudioSource death;


	// Use this for initialization
	void Start () {
		health = 100.0f;
		collide = GameObject.Find ("ColliderSource").GetComponent<AudioSource> ();
		death = GameObject.Find ("DeathSource").GetComponent<AudioSource> ();


	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		if (health > 10.0f) {
			health -= 0.005f;
		}
		if (health < 0) {
			death.Play ();
			Application.LoadLevel ("Level1");
		}
		if (shadowMaker.transform.localScale.x > (health / 30))
		{
			shadowMaker.transform.localScale -= new Vector3 (0.1f, 0.1f, 0);
		}
		if (shadowMaker.transform.localScale.x < (health / 30))
		{
			shadowMaker.transform.localScale += new Vector3 (0.1f, 0.1f, 0);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Wall") {
			health -=10.0f;
			collide.Play ();
		}
	}
}
