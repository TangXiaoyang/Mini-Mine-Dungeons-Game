using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_part2_Door_Dis : MonoBehaviour {
	public GameObject[] Tizi;
	public GameObject[] Qb;
	bool activated1 = false;
	bool activated2 = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (activated1 == false && other.name == "Player") {
			for (int i = 0; i < Tizi.Length; i++)
				Tizi [i].SetActive (true);
			activated1 = true;
		}

		if (activated2 == true && other.name == "Player") {
			for (int i = 0; i < Qb.Length; i++) {
				Qb [i].SetActive (false);
				activated2 = false;
			}
		}
	}
}
