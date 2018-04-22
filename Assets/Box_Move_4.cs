using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Move_4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void boxMo4(){
		Vector3 temp = gameObject.transform.position;
		temp.x = temp.x + 3;
		temp.y = temp.y + 2;
		gameObject.transform.position = temp;
	}
}
