using UnityEngine;
using System.Collections;

public class SetWay : MonoBehaviour {

	public GameObject[] Obj;
	Data data;

	public AudioSource sound;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
	}

	// Update is called once per frame
	void Update () {
		if (Obj[0].activeSelf == true) {
			data.wayActive = true;
		}
		if (Obj [1].activeSelf == true)
			sound.Play ();
	}
}
