using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class help : MonoBehaviour {

    bool isOpen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void help1() {
        if (!isOpen)
        {
            gameObject.SetActive(true);
            isOpen = true;
        }
        else {
            gameObject.SetActive(false);
            isOpen = false;
        }
        
    }
}
