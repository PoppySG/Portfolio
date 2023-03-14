using UnityEngine;
using System.Collections;

public class EBulletManager : MonoBehaviour {

	public GameObject bullet_prefab = null;
	public float FireCount;
	public bool hit;

	Enemy enemy;

	void Start()
	{
		enemy = FindObjectOfType<Enemy> ();
	}

	// Update is called once per frame
	void Update () {
		if (hit == true) {
			FireCount += Time.deltaTime;
			if (FireCount >= 2) {
				enemy.shot = true;
				Instantiate (bullet_prefab, this.transform.position, Quaternion.identity);
				FireCount = 0;
			}
		}
	}
}