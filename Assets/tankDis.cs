using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankDis : MonoBehaviour {
	public GameObject[] tanks;

	bool activated = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (activated == false && other.name == "Player") {
			for (int i = 0; i < tanks.Length; i++)
				tanks [i].SetActive (true);
			activated = true;
		}
	}
}
