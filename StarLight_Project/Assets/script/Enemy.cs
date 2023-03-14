using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private int enemyHP = 5;
	public GameObject[] star;
	public bool shot;
	public int i;
	public int j;

	public Animator anim;

	public Slider hpbar;

	EBulletManager ebulletManager;
	PattyWake pw;

	// Use this for initialization
	void Start () {
		ebulletManager = FindObjectOfType<EBulletManager> ();
		pw = FindObjectOfType<PattyWake> ();
		shot = false;
		hpbar.maxValue = enemyHP;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHP <= 0) {
			StartCoroutine (Dead ());
			pw.enemynum--;
		}

		if (shot == true) {
			anim.ResetTrigger ("EIdle");
			anim.SetTrigger ("EAttack");
			shot = false;
		}
	}

	IEnumerator Dead()
	{
		int i = Random.Range (0, 3);
		int j = Random.Range (1, 6);
		for (int k = 0; k < j; k++) {
			Instantiate (star [i], this.transform.position, Quaternion.identity);
		}
		yield return new WaitForFixedUpdate ();
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "bullet") {
			enemyHP--;
			hpbar.value--;
			ebulletManager.hit = true;
		}
	}
}