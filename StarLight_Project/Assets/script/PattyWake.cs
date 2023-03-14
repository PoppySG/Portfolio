using UnityEngine;
using System.Collections;

public class PattyWake : MonoBehaviour {

	public int enemynum;
	public GameObject[] npc;


	Data data;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemynum == 0 || data.BossKill) {
			npc [0].SetActive (false);
			npc [1].SetActive (true);
		}

		if (npc [2].activeSelf == true) {
			if(Input.GetKeyDown(KeyCode.LeftShift))
				data.pattyActive = false;
		}
		
		if (data.pattyActive == false)
			npc [3].SetActive (false);
	}
}
