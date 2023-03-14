using UnityEngine;
using System.Collections;

public class Clear : MonoBehaviour {

	public GameObject clear_Prefab;

	// Use this for initialization
	void Start () {
		clear_Prefab.SetActive (false);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			clear_Prefab.SetActive(true);
			Invoke("TimeStop",2f);
		}
	}


	void TimeStop()
	{
		Time.timeScale = 0;
	}
}
