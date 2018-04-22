using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2_TlDis : MonoBehaviour {
	public GameObject[] Tl;
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
			for (int i = 0; i < Tl.Length; i++)
				Tl [i].SetActive (true);
			activated = true;
		}

		if (other.name == "Player") {
			GameObject.Find ("Mine@64x64_224").SendMessage ("changeBot");
			GameObject.Find ("Mine@64x64_209").SendMessage ("changeTop");
            hint1.hint();
        }
	}
}
