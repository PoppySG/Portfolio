using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {

	public bool pattyActive;
	public bool bossActive;
	public bool portalActive;
	public bool wayActive;
	public bool BossKill;
	public bool BossDealle;
	public string route;
	public string currentScene;
	public bool First;
	public bool Second;
	public bool TalkPB;
	public bool fireWork;
	public bool seefire;
	public bool third;

	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad (this);

		pattyActive = true;
		wayActive = false;
		bossActive = false;
		BossKill = false;
		BossDealle = false;
		First = true;
		Second = true;
		TalkPB = false;
		fireWork = false;
		seefire = false;


		route = "";
		currentScene = "Stage1";
	
	}
}
