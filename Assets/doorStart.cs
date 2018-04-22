using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorStart : MonoBehaviour {
	public GameObject[] enermys;
	bool activated1 = false;
	bool activated2 = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (activated1 == false && other.name == "Player") {
			Collider2D collider = GetComponent<Collider2D> ();
			collider.isTrigger = false;
			collider.offset = Vector2.zero;
			activated1 = true;
		}
		if (activated2 == false) {
			for (int i = 0; i < enermys.Length; i++)
				enermys [i].SetActive (true);
			activated2 = true;
		}
	}
}
