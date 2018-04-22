using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1_Redflag : MonoBehaviour {
	public GameObject[] DoorOpen;
	bool activated1 = true;
	bool activated2 = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (activated2 == false && other.name == "Player") {
			for (int i = 0; i < DoorOpen.Length; i++)
				DoorOpen [i].SetActive (true);
			activated2 = true;
		}

		if (activated1 == true && other.name == "Player") {
			GameObject.Find ("MineColor2@64x64_183").SetActive(false);
			activated1 = false;
			//Destroy (GameObject.Find ("MineColor2@64x64_162"));
			Debug.Log("Suc3");
		}

	}
}
