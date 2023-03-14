using UnityEngine;
using System.Collections;

public class Street : MonoBehaviour {

	public GameObject[] Obj;
	Data data;

	public AudioSource sound;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
		sound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (data.BossDealle == true) {
			Obj [1].SetActive (true);	//팻티오빠
		}

		if (data.BossDealle == true && data.fireWork == false) {
			Obj [0].SetActive (true);	//혼잣말
		}
	}
}
