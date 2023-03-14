using UnityEngine;
using System.Collections;

public class SetPattySound : MonoBehaviour {

	public GameObject Obj;
	Data data;

	public AudioSource sound;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
	}

	// Update is called once per frame
	void Update () {
		if (Obj.activeSelf == true)
			sound.Play ();
	}
}
