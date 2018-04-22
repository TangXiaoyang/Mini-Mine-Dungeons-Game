using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //Kehui
    public Gun gun;
	public float PlayerHP = 80;
	public int evolevel = 1;
	public int MaxHP = 100;
	GameObject clostest;

    private float moveSpeed = 6f;
	bool faceRight = false;
    bool faceLeft = false;
    bool faceUp = true;
    bool faceDown = false;
	Animator animator;
	//SpriteRenderer myspe;
	public Barscript Health;
	//private  CharacterController Controller;
	private Vector3 movedirection;
	GameObject player;
	public MainMenu Theend;
	//public Transform meeple;
	public GameObject grandChild;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator> ();
		//myspe = GetComponent<SpriteRenderer> ();
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerHP > MaxHP) {
			PlayerHP = MaxHP;
		}
		Health.setfill(PlayerHP,MaxHP);

        //float x = CrossPlatformInputManager.GetAxis("Horizontal");
        //float y = CrossPlatformInputManager.GetAxis("Vertical");

        //if (Mathf.Abs(x) >= Mathf.Abs(y))
        //{
        //    transform.Translate(moveSpeed * x * Time.deltaTime, 0f, 0f);
        //    if (x > 0)
        //    {
        //        Vector3 temp = transform.localScale;
        //        temp.x = Mathf.Abs(transform.localScale.x);
        //        transform.localScale = temp;
        //        SetDirectionBool("right");
        //    }
        //    else if (x < 0)
        //    {
        //        Vector3 temp = transform.localScale;
        //        temp.x = -Mathf.Abs(transform.localScale.x); ;
        //        transform.localScale = temp;
        //        SetDirectionBool("left");
        //    }
        //    else
        //        SetDirectionBool("stop");
        //}
        //else {
        //    transform.Translate(0f, moveSpeed * y * Time.deltaTime, 0f);
        //    if (y > 0)
        //        SetDirectionBool("up");
        //    else if (y < 0)
        //        SetDirectionBool("down");
        //    else
        //        SetDirectionBool("stop");
        //}
        transform.Translate(moveSpeed * CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime, moveSpeed * CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime, 0f);



        if ((CrossPlatformInputManager.GetAxis ("Horizontal") + CrossPlatformInputManager.GetAxis ("Vertical")) == 0) {
            animator.SetBool ("walk", false);

		} else {
            animator.SetBool ("walk", true);

		}

		if (PlayerHP < 0) {
			SceneManager.LoadScene (3);
		}


		//aim display
		clostest = FindnearestEnemy ();
		Vector2 Myposi = transform.position;
		Vector2 enemyposi = clostest.transform.position;
		Vector2 enemyposi1 = enemyposi - Myposi;
		Vector2 joyS = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
		grandChild = clostest.transform.GetChild (0).gameObject;
		if ((enemyposi1 - joyS).magnitude < 5) {
			grandChild.SetActive (true);
		} else 
		{
			grandChild.SetActive (false);
		}




    }

    public void SetDirectionBool(string d) {
        faceDown = false;
        faceUp = false;
        faceRight = false;
        faceLeft = false;
        if (d.Equals("up"))
            faceUp = true;
        else if (d.Equals("left"))
            faceLeft = true;
        else if (d.Equals("down"))
            faceDown = true;
        else if (d.Equals("right"))
            faceRight = true;
        if (faceDown)
            animator.SetBool("down", true);
        else
            animator.SetBool("down", false);
        if (faceUp)
            animator.SetBool("up", true);
        else
            animator.SetBool("up", false);
        if (faceLeft)
            animator.SetBool("left", true);
        else
            animator.SetBool("left", false);
        if (faceRight)
            animator.SetBool("right", true);
        else
            animator.SetBool("right", false);
    }

    public void SetAttackedTrigger() {
        animator.SetTrigger("attacked");
    }

    public void Teleport(Vector3 pos) {
        transform.position = pos;
    }


	public GameObject FindnearestEnemy(){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("Respawn");
		GameObject closest = null;
		float Distance = Mathf.Infinity;
		Vector2 position = transform.position;
		foreach (GameObject go in gos) {
			Vector2 goposi = go.transform.position;
			Vector2 diff = goposi - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < Distance) {
				closest = go;
				Distance = curDistance;
			}
		}
		return closest;
	}

    public void Swallow()
    {
		clostest.SendMessage("Die");
    }


	public void evol(){
		if ((PlayerHP/MaxHP > 0.8)&&(evolevel<4)) {
			evolevel += 1;
			MaxHP = 100+(evolevel-1)*50;
		}
	}

	public void losehp(float a){
		PlayerHP = PlayerHP - a;
        SetAttackedTrigger();
	}

	public void Heal(float a){
		PlayerHP = PlayerHP + a;
	}

	public void speedLV (int a){
		moveSpeed = 6*a;
	}

    void map5Yd()
    {
        Vector3 temp = gameObject.transform.position;
        temp.x = temp.x + 22;
        temp.y = temp.y - 2;
        gameObject.transform.position = temp;
    }

    void room1YdLeft()
    {
        Vector3 temp = gameObject.transform.position;
        temp.x = temp.x + 4;
        temp.y = temp.y + 18;
        gameObject.transform.position = temp;
    }

    void room1YdRight()
    {
        Vector3 temp = gameObject.transform.position;
        temp.x = temp.x + 18;
        temp.y = temp.y - 3;
        gameObject.transform.position = temp;
    }

    void room2YdLeft()
    {
        Vector3 temp = gameObject.transform.position;
        temp.x = temp.x - 17;
        temp.y = temp.y - 26;
        gameObject.transform.position = temp;
    }

    void room2YdRight()
    {
        Vector3 temp = gameObject.transform.position;
        temp.x = temp.x + 18;
        temp.y = temp.y - 24;
        gameObject.transform.position = temp;
    }

    void room3YdBot()
    {
        Vector3 temp = gameObject.transform.position;
        temp.x = temp.x - 22;
        temp.y = temp.y - 3;
        gameObject.transform.position = temp;
    }

    void room3YdMid()
    {
        Vector3 temp = gameObject.transform.position;
        temp.x = temp.x - 22;
        temp.y = temp.y + 13;
        gameObject.transform.position = temp;
    }

    void room3YdTop()
    {
        Vector3 temp = gameObject.transform.position;
        temp.x = temp.x + 18;
        temp.y = temp.y - 28;
        gameObject.transform.position = temp;
    }

}
