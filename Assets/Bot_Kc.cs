using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Kc : MonoBehaviour {
	bool Bot_Kc_change = false;
	bool Bot_Kc_time = false;
    public Someha hint1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void changeBot(){
		Bot_Kc_change = true;
		Debug.Log ("here_Bot");
	}
	void botPosChange(){
		if (Bot_Kc_change == true && Bot_Kc_time == false) {
			Vector3 temp = gameObject.transform.position;
			temp.x = temp.x - 2;
			gameObject.transform.position = temp;
			Bot_Kc_time = true;
            hint1.hint();
        }
	}
}
