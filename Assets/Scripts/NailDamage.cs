using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailDamage : MonoBehaviour {

    public float nailDamage = 1f;
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            InvokeRepeating("Damage", 0f, 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player") {
            CancelInvoke("Damage");
        }
    }

    void Damage() {
        player.SendMessage("losehp", nailDamage);
    }
}
