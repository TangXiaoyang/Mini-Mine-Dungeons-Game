﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ro2_YdLeft : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			GameObject.Find ("Player").SendMessage ("room2YdLeft");
		}
	}
}
