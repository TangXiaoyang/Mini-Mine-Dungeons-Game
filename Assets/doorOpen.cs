using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.name == "Player") {
			Destroy (GameObject.Find ("doorend"));
			//Debug.Log("xxxxx");
		}
	}
}
