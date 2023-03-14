using UnityEngine;
using System.Collections;

public class bulletManager : MonoBehaviour {

	public GameObject bullet_prefab = null;
	public Animator anim;
	public AudioSource sound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Instantiate (bullet_prefab, this.transform.position, Quaternion.identity);
			anim.SetTrigger ("Fire");
			sound.Play ();
		}
	}
}
