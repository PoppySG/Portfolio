using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject[] tutorial_Prefab;
	public float timer=0;
	public bool[] active;

	void Start()
	{
		active[0] = true;
		tutorial_Prefab [0].SetActive (true);
		tutorial_Prefab [1].SetActive (false);
		tutorial_Prefab [2].SetActive (false);
		tutorial_Prefab [3].SetActive (false);
		tutorial_Prefab [4].SetActive (false);
		tutorial_Prefab [5].SetActive (false);
	}
	// Update is called once per frame
	void Update () 
	{
		if (active[0] == true)   //천천히 시작해요
		{
			timer += Time.deltaTime;
			GameObject.Find("Player").transform.Translate (-1.0f * Time.deltaTime, 0, 0);
			if(timer >= 2)
			{
				tutorial_Prefab[0].SetActive(false);
				tutorial_Prefab[1].SetActive(true);
				timer = 0; 
				active[0] = false;
				active[1] = true;
			}
		}
		if (active[1] == true) 		//맵을 돌려요
		{
			timer += Time.deltaTime;
			GameObject.Find("Player").transform.Translate (-1.0f * Time.deltaTime, 0, 0);
			if(timer >= 2)
			{
				tutorial_Prefab[1].SetActive(false);
				tutorial_Prefab[2].SetActive(true);
				timer = 0;
				active[1] = false;
				active[2] = true;
			}
		}
		if (active[2] == true) 			//아야해요
		{
			timer += Time.deltaTime;
			GameObject.Find("Player").transform.Translate (0.5f * Time.deltaTime, 0, 0);
			if(timer >= 2)
			{
				Time.timeScale = 0;
				tutorial_Prefab[2].SetActive(false);
				tutorial_Prefab[3].SetActive(true);
				timer = 0;
				active[2] = false;
				active[3] = true;
			}
		}

		if (active[3] == true) 			//스페이스바
		{
			if(Input.GetKeyDown(KeyCode.Space))
				Time.timeScale = 1;
			timer += Time.deltaTime;
			GameObject.Find("Player").transform.Translate (-1.0f * Time.deltaTime, 0, 0);
			if(timer >= 2)
			{
				tutorial_Prefab[3].SetActive(false);
				tutorial_Prefab[4].SetActive(true);
				timer = 0;
				active[3] = false;
				active[4] = true;
			}
		}
		if (active[4] == true) 			//집중해서 가요
		{
			timer += Time.deltaTime;
			GameObject.Find("Player").transform.Translate (0.5f * Time.deltaTime, 0, 0);
			if(timer >= 2)
			{
				tutorial_Prefab[4].SetActive(false);
				tutorial_Prefab[5].SetActive(true);
				timer = 0;
				active[4] = false;
				active[5] = true;
			}
		}
	}
}
