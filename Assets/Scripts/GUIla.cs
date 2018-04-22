using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIla : MonoBehaviour {
	public Player myplayer;
	public Text mytext;
	public Text HP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		mytext.text = (myplayer.evolevel.ToString());
		HP.text = Mathf.RoundToInt(myplayer.PlayerHP).ToString () + " / "+ Mathf.RoundToInt(myplayer.MaxHP).ToString ();
	}

}
