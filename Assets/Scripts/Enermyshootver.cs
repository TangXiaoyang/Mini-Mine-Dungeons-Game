using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityStandardAssets.CrossPlatformInput;


public class Enermyshootver : MonoBehaviour {

	public int hp = 100;
	public int hpmax = 100;
	int swallowableBoundary = 30;
	float swallowableDistance = 5f;
	GameObject player;
	System.Random random;
	System.Timers.Timer timer;
	public EnemyGun enemyGun;
	public Visionshoot vision;
    Animator animator;
	public SimpleHealthBar healthBar;
	public GameObject grandChild;

	public void Die() {
		//hp -= 1;
		Debug.Log ("testswa");
		if (hp < swallowableBoundary && Vector2.Distance (transform.position, player.transform.position) < swallowableDistance) {
			Destroy (gameObject);
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
		random = new System.Random();
		timer = new System.Timers.Timer();
		timer.AutoReset = true;
		InvokeRepeating("enemyShoot", 1.0f, 1.0f);
        animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (hp < 0) {
			Destroy (gameObject);
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

	private void enemyShoot () {
		if (vision.haveSightOfPlayer) {
			enemyGun.shoot();
		}

	}

}
