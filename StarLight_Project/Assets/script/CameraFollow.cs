using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;

	//public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;

	public float shakeTimer;
	public float shakeAmount;
	public bool isShake;
	public float RightSide;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find ("CharacterManager");
		isShake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);

		transform.position = new Vector3 (posX, transform.position.y, transform.position.z);

		if (transform.position.x <= -20.28f)
			transform.position = new Vector3 (-20.28f, 0f, -10f);

		if (transform.position.x >= RightSide)
			transform.position = new Vector3 (RightSide, 0f, -10f);

		if (shakeTimer >= 0) {
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y, transform.position.z);
			shakeTimer -= Time.deltaTime;	
		}

		if (isShake == true) {
			ShakeCamera (0.1f, 1);
			isShake = false;
		}
	}

	public void ShakeCamera(float shakePwr, float shakeDur)
	{
		shakeAmount = shakePwr;
		shakeTimer = shakeDur;
	}
}
