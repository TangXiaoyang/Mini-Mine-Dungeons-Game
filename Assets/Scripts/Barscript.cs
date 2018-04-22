using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barscript : MonoBehaviour {
	[SerializeField]
	public float fillamount;

	[SerializeField]
	private Image HealthbarFill;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HandleBar ();
	}
		

	public void HandleBar(){
		HealthbarFill.fillAmount = fillamount;
	}

	public void setfill(float a,float b){
		fillamount = a / b;
	}
}
