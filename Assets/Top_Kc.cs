using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top_Kc : MonoBehaviour {
	bool Top_Kc_change = false;
	bool Top_Kc_time = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void changeTop()
	{
		Top_Kc_change = true;
		Debug.Log("here_top");
	}
	void topPosChange(){
		if (Top_Kc_change == true && Top_Kc_time == false) {
			Vector3 temp = gameObject.transform.position;
			temp.x = temp.x - 2;
			gameObject.transform.position = temp;
			Top_Kc_time = true;
		}
	}
}
