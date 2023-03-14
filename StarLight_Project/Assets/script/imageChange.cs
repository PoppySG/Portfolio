using UnityEngine;
using System.Collections;

public class imageChange : MonoBehaviour {

	character _character;

	public GameObject[] prefab;
	public float attackTime = 0;
	public bool _attack;

	// Use this for initialization
	void Start () {
		_character = GameObject.Find ("character").GetComponent<character> ();

		prefab [0].SetActive (true);
		prefab [1].SetActive (false);
		_attack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			prefab [0].SetActive (false);
			prefab [1].SetActive (true);
			_attack = true;
			attackTime = 0;
		}
		if (_attack == true) {
			attackTime += Time.deltaTime;
		}
		if(attackTime > 6) {
			//공격중 상태시간 수정해야됨.
			prefab [0].SetActive (true);
			prefab [1].SetActive (false);
			_attack = false;
			attackTime = 0;
			_character.state_time = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Popup") {
			prefab [0].SetActive (true);
			prefab [1].SetActive (false);
		}
	}
}
