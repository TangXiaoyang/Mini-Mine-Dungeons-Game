using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Move_3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void boxMo3(){
		Vector3 temp = gameObject.transform.position;
		temp.x = temp.x + 3;
		gameObject.transform.position = temp;
	}
}
