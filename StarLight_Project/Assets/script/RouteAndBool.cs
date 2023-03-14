using UnityEngine;
using System.Collections;

public class RouteAndBool : MonoBehaviour {

	public Sprite CurrentSprite;
	public Sprite NextSprite;
	private SpriteRenderer spriteRenderder;

	public GameObject[] Obj;
	Data data;

	// Use this for initialization
	void Start () {

		data = FindObjectOfType<Data> ();

		spriteRenderder = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderder.sprite = CurrentSprite;

		if (data.bossActive == false && data.BossKill == false) {
			Obj[3].SetActive(true);			//NPC들
			Obj[6].SetActive(false);		//보스체력UI
			Obj[8].SetActive(false);		//보스전 대화
		}
	}
	
	// Update is called once per frame
	void Update () {

		/////////////팻티//////////////////
		if (data.pattyActive == true) {
			Obj[0].SetActive (true); //첫부분팻티
		} else {
			Obj[0].SetActive (false);
		}

		/////////////새로운 길/////////////
		if (data.wayActive == true)
			Obj [5].SetActive (true);
		if (data.wayActive == false)
			Obj [5].SetActive (false);

		///////////////포탈///////////////
		if (data.portalActive == false)
			Obj [2].SetActive (false);
		if (data.portalActive == true)
			Obj [2].SetActive (true);

		/////////////보스//////////////////


		if (data.bossActive == true) {
			
			Obj[1].SetActive (true);		//보스
			Obj[3].SetActive(false);		//NPC들
			Obj[4].SetActive(true);			//보스부분팻티
			Obj[6].SetActive(true);			//보스체력UI
			//data.wayActive = false;		//딜르방 가는길
			Obj[8].SetActive(true);			//보스전 대화
		}
		if (data.BossKill == true) {
			data.bossActive = false;
			data.wayActive = true;
			//data.portalActive = true;
			Obj[6].SetActive(false);		//보스체력UI
			Obj[8].SetActive(false);		//보스전 대화
		}
		if (data.BossKill == true && data.third == false)
			data.portalActive = true;
		//////////////익스포포//////////////
		if (data.BossDealle == true) {
			Obj [7].SetActive (true);		//익스포포
			spriteRenderder.sprite = NextSprite;
			Obj[4].SetActive(false);		//보스부분팻티
		}
	}
}
