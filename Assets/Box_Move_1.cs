using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Move_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void boxMo1(){
		Vector3 temp = gameObject.transform.position;
		temp.y = temp.y - 4;
		gameObject.transform.position = temp;
	}
}
