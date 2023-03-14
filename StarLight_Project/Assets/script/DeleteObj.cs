using UnityEngine;
using System.Collections;

public class DeleteObj : MonoBehaviour {

	private float deleteCount;

	// Use this for initialization
	void Start () {
		deleteCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		deleteCount += Time.deltaTime;

		if(deleteCount >= 10f)
			Destroy (this.gameObject);
	}
}
