using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******** this file detects the player for enemes *********/

public class Visionshoot : MonoBehaviour {

	private RaycastHit2D vision;
	private float rayLength;
	GameObject player;
	float moveSpeed = 0.02f;
	public bool haveSightOfPlayer = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		rayLength = 20.0f;
	}

	// Update is called once per frame
	void Update () {
		Debug.DrawRay(gameObject.transform.position, player.transform.position, Color.red, 0.01f);


		vision = Physics2D.Raycast(gameObject.transform.position, player.transform.position - gameObject.transform.position, rayLength);

		if (vision.collider != null) {
			//Debug.Log("the tag is " + vision.collider.tag);
			if (vision.collider.tag == "Player")
			{
				//Debug.Log("Hitted");
				//transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed);
				haveSightOfPlayer = true;
			}
			else {
				//Debug.Log("notHitted");
				haveSightOfPlayer = false;
			}
		}

	}

}
