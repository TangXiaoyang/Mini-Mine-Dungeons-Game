using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1_Snq_Des : MonoBehaviour {
	public GameObject[] Snq;
	public GameObject[] Snd;
	bool activated1 = true;
	bool activated2 = false;
    public Someha hint1;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (activated1 == true && other.name == "Player") {
			for (int i = 0; i < Snq.Length; i++)
				Snq [i].SetActive (false);
			activated1 = false;
            hint1.hint();
		}

		if (activated2 == false && other.name == "Player") {
			for (int i = 0; i < Snd.Length; i++) {
				Snd [i].SetActive (true);
				activated2 = true;
			}
		}
	}
}
