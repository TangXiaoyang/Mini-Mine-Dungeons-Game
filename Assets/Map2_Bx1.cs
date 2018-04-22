using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2_Bx1 : MonoBehaviour {
	public GameObject[] Dkbx_map21;
	bool activated1 = false;
	bool activated2 = true;
	GameObject gos;
	// Use this for initialization
	void Start () {
		gos = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (activated1 == false && other.name == "Player") {
			for (int i = 0; i < Dkbx_map21.Length; i++)
				Dkbx_map21 [i].SetActive (true);
			activated1 = true;
			gos.SendMessage ("Heal", 80);
		}

		if (activated2 == true && other.name == "Player") {
			GameObject.Find ("Mine@64x64_162").SetActive(false);
			activated2 = false;
			//Destroy (GameObject.Find ("MineColor2@64x64_162"));
			Debug.Log("Suc1");
		}
	}
}
