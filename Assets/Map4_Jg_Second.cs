using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map4_Jg_Second : MonoBehaviour {
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
			GameObject.Find ("Mine@64x64_193 (3)").SendMessage ("boxMo2");
			activated = true;
            hint1.hint();
        }
	}
}
