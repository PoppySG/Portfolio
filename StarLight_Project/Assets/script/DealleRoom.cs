using UnityEngine;
using System.Collections;

public class DealleRoom : MonoBehaviour {

	Data data;
	public GameObject[] Obj;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();

		if (data.BossKill == true) {
			Obj [0].SetActive (false);	//책있는책장
			Obj [1].SetActive (true);	//책없는책장
			Obj [2].SetActive (false);	//딜르
			Obj	[3].SetActive(true);	//혼잣말1
		}
	}
	
	// Update is called once per frame
	void Update () {
		

			if (Obj [3].activeSelf == true)
				data.BossDealle = true;

		if (data.fireWork == true)
		{
			Obj [3].SetActive (false);
			Obj [4].SetActive (true);	//혼잣말2
		}
	}
}
