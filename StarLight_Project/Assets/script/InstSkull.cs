using UnityEngine;
using System.Collections;

public class InstSkull : MonoBehaviour {

	public GameObject[] skull;
	private int num;

	// Use this for initialization
	void Start () {
		StartCoroutine (ShowSkull ());
	}
	
	// Update is called once per frame
	void Update () {
		//StartCoroutine (ShowSkull ());
	}

	IEnumerator ShowSkull()
	{
		for (num = 0; num <= 5; num++) {
			skull [num].SetActive (true);
			yield return new WaitForSeconds (.5f);
		}
	}
}
