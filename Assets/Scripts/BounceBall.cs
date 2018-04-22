using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour {

    private Vector3 init_direction = new Vector3(0, 0, 0);
    private Vector3 dest;
    public float move_speed;
    public float bounce_ball_damage;
    public int exist_time = 5;

    public void SetDirection(Vector3 init_d) {
        init_direction = init_d;
    }

	// Use this for initialization
	void Start () {
        dest = transform.position + init_direction;
        Destroy(gameObject, exist_time);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, dest, move_speed * Time.deltaTime);
        if (gameObject.GetComponent<Collider2D>().IsTouching(GameObject.Find("Player").GetComponent<Collider2D>())) {
            GameObject.Find("Player").SendMessage("losehp", bounce_ball_damage);
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Respawn") {
            //Destroy(coll.gameObject);
        }
    }

}
