using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Move_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void boxMo2(){
		Vector3 temp = gameObject.transform.position;
		temp.x = temp.x - 3;
		gameObject.transform.position = temp;
	}
}
