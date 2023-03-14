using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossMove : MonoBehaviour {

	public Animator anim;
	private Vector2 velocity;

	//public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;
	public GameObject[] bossPatern;

	public int bossHP;
	public float hitcount;

	public bool isHit;
	public bool isSpell;
	public float spellCount;

	public Slider hpbar;
	public AudioSource[] sound;
	CameraFollow cf;
	Data data;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("CharacterManager");
		bossHP = 50;
		isHit = false;
		cf = FindObjectOfType<CameraFollow> ();
		data = FindObjectOfType<Data> ();
		hpbar.maxValue = bossHP;
	}

	// Update is called once per frame
	void Update () {

		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		//float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, transform.position.y, transform.position.z);

		if (transform.position.x <= -20.28f)
			transform.position = new Vector3 (-20.28f, 0.17f, 1f);



		////////////////////// 보스 패턴 ////////////////////////////////////

		if(Input.GetKeyDown(KeyCode.Alpha1))	//패턴1 - 유도 미사일
			Instantiate(bossPatern[0], this.transform.position, Quaternion.identity);

		if(Input.GetKeyDown(KeyCode.Alpha2))	//패턴2 - 튕기는 미사일
			Instantiate(bossPatern[1], this.transform.position, Quaternion.identity);

		if(Input.GetKeyDown(KeyCode.Alpha3))	//패턴3 - 떨어지는 해골
			Instantiate(bossPatern[2], new Vector2(player.transform.position.x,2f), Quaternion.identity);


		/////////////////체력별 패턴///////////////////////

		//hpbar.maxValue = bossHP;

		if (bossHP == 48 && isHit == true) {
			cf.isShake = true;
			StartCoroutine (Pattern3A (0)); 
			sound [0].Play ();
		}
		
		if (bossHP == 45 && isHit == true) {
			cf.isShake = true;
			StartCoroutine (Pattern3A (0));
			StartCoroutine (Pattern3B (1f));
			sound [0].Play ();
		}

		if (bossHP == 40 && isHit == true) {
			cf.isShake = true;
			StartCoroutine (Pattern3C (0));
			sound [0].Play ();
		}

		if (bossHP == 38 && isHit == true) {
			cf.isShake = true;
			StartCoroutine (Pattern3D (0));
			sound [0].Play ();
		}

		if (bossHP == 35 && isHit == true) {
			cf.isShake = true;
			StartCoroutine (Pattern3C (0));
			StartCoroutine (Pattern3D (2f));
			sound [0].Play ();
		}

		if (bossHP == 30 && isHit == true) {
			cf.isShake = true;
			StartCoroutine (Pattern2 ());
			StartCoroutine (Pattern3A (0));
			StartCoroutine (Pattern3B (1f));
			StartCoroutine (Pattern3C (2f));
			cf.isShake = true;
			StartCoroutine (Pattern3D (4f));
			sound [0].Play ();
		}

		if (bossHP == 20 && isHit == true) {
			StartCoroutine (Pattern1 ("1A"));
			StartCoroutine (Pattern1 ("1B"));
			StartCoroutine (Pattern2 ());
			StartCoroutine (Pattern3C (0));
			StartCoroutine (Pattern3D (2f));
			sound [0].Play ();
		}

		if (bossHP == 10 && isHit == true) {
			StartCoroutine (Pattern2 ());
			StartCoroutine (Pattern1 ("1A"));
			StartCoroutine (Pattern1 ("1B"));
			StartCoroutine (Pattern1 ("1C"));
			StartCoroutine (Pattern1 ("1D"));
			sound [0].Play ();
		}

		if (bossHP == 5 && isHit == true) {
			StartCoroutine (Pattern2 ());
			StartCoroutine (Pattern1 ("1A"));
			StartCoroutine (Pattern1 ("1B"));
			StartCoroutine (Pattern1 ("1C"));
			StartCoroutine (Pattern1 ("1D"));
			StartCoroutine (Pattern3A (0));
			StartCoroutine (Pattern3B (1f));
			sound [0].Play ();
		}
		

		if (bossHP <= 0) {
			sound [1].Play ();
			Destroy (this.gameObject);
			data.BossKill = true;
			data.bossActive = false;
		}
		else {
			isHit = false;
		}
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "bullet" && isSpell == false) {
			bossHP--;
			hpbar.value--;
			isHit = true;
			StartCoroutine (Hit ());
		}
	}

	IEnumerator Hit()
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		renderer.color = new Color (1f, 0.2f, 0.2f);
		yield return new WaitForSeconds (.05f);
		renderer.color = new Color (1f, 1f, 1f);
	}

	IEnumerator Pattern1(string instName)	//패턴1 - 유도 미사일
	{
		isHit = false;
		anim.ResetTrigger ("BIdle");
		anim.SetTrigger ("BSpell");
		yield return new WaitForSeconds(.5f);
		Instantiate (bossPatern [0], this.transform.Find(instName).position, Quaternion.identity);
		yield return new WaitForSeconds (1f);
		anim.ResetTrigger ("BSpell");
		anim.SetTrigger ("BIdle");
	}

	IEnumerator Pattern2()	//패턴2 - 튕기는 미사일
	{
		isHit = false;
		anim.ResetTrigger ("BIdle");
		anim.SetTrigger ("BSpell");
		yield return new WaitForSeconds(.5f);
		Instantiate (bossPatern [1], new Vector2 (player.transform.position.x, 2f), Quaternion.identity);
		yield return new WaitForSeconds (1f);
		anim.ResetTrigger ("BSpell");
		anim.SetTrigger ("BIdle");
	}

	IEnumerator Pattern3A(float waitTime)	//패턴3 - 떨어지는 해골A
	{
		yield return new WaitForSeconds (waitTime);
		isSpell = true;
		isHit = false;
		anim.ResetTrigger ("BIdle");
		anim.SetTrigger ("BSpell");
		yield return new WaitForSeconds(.5f);
		Instantiate (bossPatern [2], new Vector2 (player.transform.position.x, 2f), Quaternion.identity);
		yield return new WaitForSeconds (1f);
		anim.ResetTrigger ("BSpell");
		anim.SetTrigger ("BIdle");
		isSpell = false;
	}
	IEnumerator Pattern3B(float waitTime)	//패턴3 - 떨어지는 해골B
	{
		yield return new WaitForSeconds (waitTime);
		isSpell = true;
		isHit = false;
		anim.ResetTrigger ("BIdle");
		anim.SetTrigger ("BSpell");
		yield return new WaitForSeconds(.5f);
		Instantiate (bossPatern [3], new Vector2 (player.transform.position.x, 2f), Quaternion.identity);
		yield return new WaitForSeconds (1f);
		anim.ResetTrigger ("BSpell");
		anim.SetTrigger ("BIdle");
		isSpell = false;
	}
	IEnumerator Pattern3C(float waitTime)	//패턴3 - 떨어지는 해골C
	{
		yield return new WaitForSeconds (waitTime);
		isSpell = true;
		isHit = false;
		anim.ResetTrigger ("BIdle");
		anim.SetTrigger ("BSpell");
		yield return new WaitForSeconds(.5f);
		Instantiate (bossPatern [4], new Vector2 (player.transform.position.x, 2f), Quaternion.identity);
		yield return new WaitForSeconds (1f);
		anim.ResetTrigger ("BSpell");
		anim.SetTrigger ("BIdle");
		isSpell = false;
	}
	IEnumerator Pattern3D(float waitTime)	//패턴3 - 떨어지는 해골D
	{
		yield return new WaitForSeconds (waitTime);
		isSpell = true;
		isHit = false;
		anim.ResetTrigger ("BIdle");
		anim.SetTrigger ("BSpell");
		yield return new WaitForSeconds(.5f);
		Instantiate (bossPatern [5], new Vector2 (player.transform.position.x, 2f), Quaternion.identity);
		yield return new WaitForSeconds (1f);
		anim.ResetTrigger ("BSpell");
		anim.SetTrigger ("BIdle");
		isSpell = false;
	}
}

