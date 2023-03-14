using UnityEngine;
using System.Collections;

public class SetSound : MonoBehaviour {

	public AudioSource[] sound;
	Data data;

	// Use this for initialization
	void Start () {
		data = FindObjectOfType<Data> ();

		if (data.bossActive == false)
			sound [0].Play ();		//마을브금
		
		if (data.bossActive == true)
			sound [1].Play ();		//보스브금
	}

	void Update()
	{
		if (data.BossKill == true) 
		{
			sound [1].Stop ();
		}
	}
}
