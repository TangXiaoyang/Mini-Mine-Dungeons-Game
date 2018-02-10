using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	//Kehui
	public Gun gun;

    private float moveSpeed = 6f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(moveSpeed * CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime, moveSpeed * CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime, 0f);
    	
		//Kehui
		if (Input.GetButtonDown("Shoot")) {
			gun.shoot ();
		}
	}

    public void Swallow()
    {
        if(GameObject.Find("Enermy"))
            GameObject.Find("Enermy").SendMessage("Die");
    }
}
