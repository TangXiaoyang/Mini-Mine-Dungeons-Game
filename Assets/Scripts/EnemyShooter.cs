using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********* this file shoot the bullets *********/

public class EnemyShooter : MonoBehaviour {

    public float speed;
    public float power;
    void Update() {
        
    }

    public void FindAndShoot() {
        Vector2 EnermyPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 Myposi = transform.position;
        Vector2 direction = EnermyPos - Myposi;
        transform.rotation = Quaternion.Euler(direction);
        GetComponent<Rigidbody2D>().velocity = (speed * direction)/Mathf.Abs(direction.magnitude);
    }


	void Start () {
        FindAndShoot();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag ("Player").SendMessage ("losehp", power);
			Destroy (gameObject);
		} else if (other.tag == "Wall") {
			Destroy (gameObject);
		}
	}
}
