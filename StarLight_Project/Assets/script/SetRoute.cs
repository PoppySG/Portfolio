using UnityEngine;
using System.Collections;

public class SetRoute : MonoBehaviour {

	public GameObject[] Obj;
	Data data;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Obj[0].activeSelf == true)	//A루트
			data.route = "A";
		if(Obj[1].activeSelf == true)	//B루트
			data.route = "B";
	}
}
