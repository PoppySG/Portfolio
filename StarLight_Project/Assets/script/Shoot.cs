using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet_prefab = null;
	public float FireCount;

	Enemy enemy;

	// Use this for initialization
	void Start () {
		enemy = FindObjectOfType<Enemy> ();
	}
	
	// Update is called once per frame
	void Update () {
		FireCount += Time.deltaTime;
		if (FireCount >= 2) {
			enemy.shot = true;
			Instantiate (bullet_prefab, this.transform.position, Quaternion.identity);
			FireCount = 0;
		}
	}
}
