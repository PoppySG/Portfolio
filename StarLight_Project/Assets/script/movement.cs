using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour {
	
	public float speed = 1;
	public int playerHP;
	public float playerposX;
	public float playerposY;
	public int routeNum;

	public bool is_jump;
	public bool c_right;
	public bool onLoad;
	public bool is_potal;
	public bool is_hit;

	public bool onladder;
	public bool onClimb;

	public float jumpHeight = 200;

	public AudioSource sound;
	public Slider hpbar;

	NPC npc;
	Potal potal;
	PortalData PD;


	// Use this for initialization
	void Start () {

		//DontDestroyOnLoad (this.gameObject);

		is_jump = true;
		onladder = false;
		onClimb = false;
		c_right = true;
		is_hit = false;

		npc = FindObjectOfType<NPC> ();
		potal = FindObjectOfType<Potal> ();
		PD = FindObjectOfType<PortalData> ();

		string value = PlayerPrefs.GetString ("load", "false");
		bool onLoad = System.Convert.ToBoolean (value);

		if (onLoad == true ) {
			playerposX = PlayerPrefs.GetFloat ("XPos");
			playerposY = PlayerPrefs.GetFloat ("YPos");
			Vector2 posVec = new Vector2 (playerposX, playerposY);
			transform.position = posVec;
			onLoad = false;
		} 
		if (PD.getPotal == true) {
			playerposX = PD.PosX;
			playerposY = PD.PosY;
			transform.position = new Vector2 (playerposX, playerposY);
			PD.getPotal = false;
		}
		else {
			playerposX = -22.8f;
			playerposY = -1.48f;
			transform.position = new Vector2 (playerposX, playerposY);
		}
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Alpha9))
			SceneManager.LoadScene ("Title");

		//string value2 = PlayerPrefs.GetString ("potal", "false");
		//bool onLoad2 = System.Convert.ToBoolean (value2);

		/*if (potal.is_potal == true) {
			playerposX = -22.8f;
			playerposY = -1.48f;
			potal.is_potal = false;
		}*/
		/////////////////////좌우 이동///////////////////////
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-speed * Time.deltaTime, 0, 0);
			c_right = false;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (speed * Time.deltaTime, 0, 0);
			c_right = true;
		}

		/////////////////////사다리 이동///////////////////////
		if (onladder == true) {
			//myrigidbody2D.gravityScale = 0;
			if (Input.GetKey (KeyCode.W)) {
				onClimb = true;
				transform.Translate (0, speed * Time.deltaTime, 0);
			}
			if (Input.GetKey (KeyCode.S)) {
				onClimb = true;
				transform.Translate (0, -speed * Time.deltaTime, 0);
			}
			if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.S)) {
				onClimb = false;
			}
		}
		if (onladder == false) {
			//myrigidbody2D.gravityScale = 1f;
		}

		//////////////////////점프///////////////////////////////
		if (Input.GetKey (KeyCode.Space)) {
			Jump ();
		} 

		/////////////////////체력 바/////////////////////////////
		hpbar.maxValue = playerHP;

		if (hpbar.value <= 0)
			SceneManager.LoadScene ("Title");
		/*if (playerHP >= 5)
			playerHP = 5;*/

		////////////////////저장/////////////////////////////////
		playerposX = transform.position.x;
		playerposY = transform.position.y;

		PlayerPrefs.SetFloat ("XPos", playerposX);
		PlayerPrefs.SetFloat ("YPos", playerposY);
	}


	void Jump()
	{
		if (is_jump == true) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(0,jumpHeight));
			sound.Play ();
			is_jump = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "ground") {
			is_jump = true;
		}

	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.name == "Wall1") {
			transform.Translate (speed * Time.deltaTime, 0, 0);
		}
		if (col.gameObject.name == "Wall2") {
			transform.Translate (-speed * Time.deltaTime, 0, 0);
		}
		if (col.gameObject.name == "bridge") {
			if (onladder == false) {
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Ladder")
			onladder = true;
		if (col.tag == "NPC") {
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				npc.is_check = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "NPC")
			npc.is_check = false;
		if (col.tag == "Ladder")
			onladder = false;
	}
}
