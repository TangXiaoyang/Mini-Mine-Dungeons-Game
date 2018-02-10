using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    private float moveSpeed = 6f;
	bool Faceright=true;
	Animator testwalk;
	SpriteRenderer myspe;

    // Use this for initialization
    void Start () {
		testwalk = GetComponent<Animator> ();
		myspe = GetComponent<SpriteRenderer> ();



		//triggerhp = Enermy

	}
	
	// Update is called once per frame
	void Update () {
		float direction = CrossPlatformInputManager.GetAxis ("Horizontal");
		if (direction > 0 && Faceright == false) {
			Faceright = !Faceright;
			myspe.flipX = false;
		} else if (direction < 0 && Faceright == true) {
			Faceright = !Faceright;
			myspe.flipX = true;
		}
		GameObject theenermy = GameObject.Find("Enermy");
		if (theenermy == null) {
			testwalk.SetTrigger ("");
		}




        transform.Translate(moveSpeed * CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime, moveSpeed * CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime, 0f);
		if ((CrossPlatformInputManager.GetAxis ("Horizontal") + CrossPlatformInputManager.GetAxis ("Vertical")) == 0) {
			testwalk.SetBool ("iswalk", false);

		} else {
			testwalk.SetBool ("iswalk", true);

		}
    }

    public void Swallow()
    {
        if(GameObject.Find("Enermy"))
            GameObject.Find("Enermy").SendMessage("Die");
    }
	public void swallowanime(){
		testwalk.SetTrigger("Swa");
	}
}
