using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Someha : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void disa()
    {
        gameObject.SetActive(false);
    } 

    public void hint() {
        gameObject.SetActive(true);
        Invoke("disa", 2f);
    }
}
