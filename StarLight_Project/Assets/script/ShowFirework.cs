using UnityEngine;
using System.Collections;

public class ShowFirework : MonoBehaviour {

	public GameObject[] Obj;
	Data data;


	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Obj [0].activeSelf == true)
			Obj [3].SetActive (true);

		if (Obj [1].activeSelf == true)
			Obj [2].SetActive (true);
	}
}
