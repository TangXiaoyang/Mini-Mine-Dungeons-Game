using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Boss : MonoBehaviour {

    public GameObject chasingEnemyPrefab;
    public GameObject bullet;
    public float health = 1000;
	public float maxhealth = 1000;
    public float suck_damage = 5;
    public float suck_health_gain = 100;
    public Vision vision;
    public float bullet_speed = 0.01f;
    private GameObject player;
    public int number_of_bullets = 5; // this has to be odd
    public int number_of_summon = 3;
    public float angle = 30f;
    public float offset = 3f;
    public float bullet_size = 0.7f;
    Animator animator;
	public SimpleHealthBar healthBar;
	public GameObject grandChild;
    public float frequency;
    public int waterball_damage;
	public Finish fin;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        InvokeRepeating("Attack", 0f, frequency * 3f);
        InvokeRepeating("Summon", frequency, frequency * 3f);
        InvokeRepeating("SuckBlood", 2 * frequency, frequency * 3f);
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
            Destroy(gameObject);
			fin.Load ();
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

    void Attack() {
        SetAttackTrigger();
        Vector2 dire = player.transform.position - gameObject.transform.position;
        if (vision.haveSightOfPlayer) {
            for (int i = -number_of_bullets / 2; i <= number_of_bullets / 2; ++i) {
                GameObject go = (GameObject)Instantiate(bullet);
                go.transform.position = gameObject.transform.position;
                go.transform.localScale = new Vector3(bullet_size, bullet_size, 0);
                go.SendMessage("SetDirection", Quaternion.Euler(0, 0, i * angle) * dire * 100);
            }
        }
    }

    void Summon() {
        SetAttackTrigger();
        if (vision.haveSightOfPlayer) {
            Vector3 dire = player.transform.position - gameObject.transform.position;
            for (int i = -number_of_summon / 2; i <= number_of_summon / 2; ++i)
            {
                GameObject go = (GameObject)Instantiate(chasingEnemyPrefab);
                go.transform.position = gameObject.transform.position + Quaternion.Euler(0, 0, i * angle * 2) * dire * offset / dire.magnitude;
            }
        }
    }

    void SuckBlood() {
        SetAttackTrigger();
        if (vision.haveSightOfPlayer) {
            GameObject.Find("Player").SendMessage("losehp", suck_damage);
            health += suck_health_gain;
        }
    }

    void SetAttackTrigger() {
        animator.SetTrigger("attack");
    }

	void WaterballHp(int attack) {
		health -= waterball_damage;
		healthBar.UpdateBar (health, maxhealth);
		animator.SetTrigger ("attacked");

    }
}
