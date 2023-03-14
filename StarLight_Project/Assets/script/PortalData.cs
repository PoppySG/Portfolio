using UnityEngine;
using System.Collections;

public class PortalData : MonoBehaviour {

	public bool getPotal;
	public bool[] portalnum;
	public float PosX;
	public float PosY;

	movement _movement;
	Potal potal;
	Data data;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		_movement = FindObjectOfType<movement> ();
		potal = FindObjectOfType<Potal> ();
		data = FindObjectOfType<Data>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (portalnum [0] == true) {		// 1 -> 1.5
			PosX = -22.8f;
			PosY = -1.48f;
			data.currentScene = "Stage1.5";
			portalnum [0] = false;
		}
		if (portalnum [1] == true) {		// 1 <- 1.5
			PosX = 22.98f;
			PosY = -1.48f;
			data.currentScene = "Stage1";
			portalnum [1] = false;
		}
		if (portalnum [2] == true) {		//1.5 -> 2
			PosX = -22.8f;
			PosY = -1.48f;
			data.currentScene = "Stage2";
			portalnum [2] = false;
		}
		if (portalnum [3] == true) {		//2 -> 1.5
			PosX = 8.23f;
			PosY = 0f;
			data.currentScene = "Stage1.5";
			portalnum [3] = false;
		}
		if (portalnum [4] == true) {		//2 -> Dealle
			PosX = -22.8f;
			PosY = -1.48f;
			data.currentScene = "StageDealle";
			portalnum [4] = false;
		}
		if (portalnum [5] == true) {		//Dealle -> 2
			PosX = -6.02f;
			PosY = 0.35f;
			data.currentScene = "Stage2";
			portalnum [5] = false;
		}
		if (portalnum [6] == true) {		//2 -> BackStreet
			PosX = -22.8f;
			PosY = -1.48f;
			data.currentScene = "StageStreet";
			portalnum [6] = false;
		}
		if (portalnum [7] == true) {		//BackStreet -> 2
			PosX = -14.68f;
			PosY = -1.48f;
			data.currentScene = "Stage2";
			portalnum [7] = false;
		}

	}
}
