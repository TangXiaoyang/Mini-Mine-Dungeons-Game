using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityStandardAssets.CrossPlatformInput;

public class Enermy : MonoBehaviour {

    public int hp = 100;
	public int hpmax = 100;
    public int swallowableBoundary = 30;
    public float moveSpeed = 0.02f;
    public float swallowableDistance = 2.5f;
    GameObject player;
    System.Random random;
    public Vision vision;
    Animator animator;
	public SimpleHealthBar healthBar;
	public GameObject grandChild;

    public void Die() {
        //hp -= 1;
		Debug.Log(hp);

		Debug.Log(hp+" " + swallowableBoundary);
		if (hp < swallowableBoundary && Vector2.Distance (transform.position, player.transform.position) < swallowableDistance) {
			Destroy(gameObject);
			GameObject.FindGameObjectWithTag ("Player").SendMessage ("Heal", 20);
		
		}

    }

	public void WaterballHp(int attack)
    {
		hp -= attack;
		healthBar.UpdateBar( hp, hpmax );
		animator.SetTrigger("attacked");
	}

    // Use this for initialization
    void Start () {
		player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (hp < 0) {
			Destroy (gameObject);
		}
        if (vision.haveSightOfPlayer)
        {
            animator.SetBool("walk", true);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed);
        }
        else {
            animator.SetBool("walk", false);
        }

		//aim 

		Vector2 joyS = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
		Vector2 Myposi = transform.position;
		Vector2 enemyposi = player.transform.position;
		Vector2 enemyposi1 = Myposi -enemyposi;
		grandChild = gameObject.transform.GetChild (0).gameObject;
		if ((enemyposi1 - joyS).magnitude >5) {
			grandChild.SetActive (false);
		}


    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").SendMessage("losehp", 20);
            GameObject.Find("Player").SendMessage("SetAttackedTrigger");
        }
    }
    
}
