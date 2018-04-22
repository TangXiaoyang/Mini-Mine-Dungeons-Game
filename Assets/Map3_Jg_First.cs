using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map3_Jg_First : MonoBehaviour {
	bool activated = false;
    public Someha hint1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (activated == false && other.name == "Player") {
			GameObject.Find ("Mine@64x64_193 (1)").SendMessage ("boxMo1");
			activated = true;
            hint1.hint();
        }
	}
}
