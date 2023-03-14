using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public bool is_Q = false;
	public bool check1 = false;
	public bool check2 = false;

	string s;
	public string[] fullText;
	private string currentText = "";
	public int textnum = 0;
	public int qnum;

	public GameObject check;
	public GameObject mDialogue;	//삭제하려는 대화창
	public GameObject nDialogue;	//추가로 나오는 대화창

	Popup popup;

	// Use this for initialization
	void Start () {
		popup = FindObjectOfType<Popup> ();

		StartCoroutine (ShowText ());
	}

	void OnEnable()
	{
		StartCoroutine (ShowText ());
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			textnum++;
			StartCoroutine (ShowText ());
		}
		if (fullText.Length <= textnum) {
			//InitDialogue ();
			if (mDialogue == null) {
				popup.is_delete = true;
			} else {
				StartCoroutine (InitDialogue ());
				popup.is_popup = false;
				mDialogue.SetActive (false);
				nDialogue.SetActive (true);
			}
		}

		if (check != null) {
			if (textnum == qnum)
				is_Q = true;
			if (is_Q == true) {
				check.SetActive (true);
			} else
				check.SetActive (false);
		}
	}

	IEnumerator InitDialogue()
	{
		textnum = 0;
		is_Q = false;
		yield return null;
	}

	IEnumerator ShowText()
	{
		for (int i = 0; i <= fullText[textnum].Length; i++) {
			fullText [textnum] = fullText [textnum].Replace ("\\n", "\n");
			currentText = fullText [textnum].Substring (0, i);
			this.GetComponent<Text> ().text = currentText;
			yield return new WaitForSeconds (.05f);
		}
	}
}
