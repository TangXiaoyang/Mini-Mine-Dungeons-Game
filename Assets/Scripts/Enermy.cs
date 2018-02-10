using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour {

    int hp = 100;
    int swallowableBoundary = 80;
    float moveSpeed = 0.02f;
    float swallowableDistance = 1f;
    GameObject player;

    public void Die() {
        hp -= 10;
        if (hp < swallowableBoundary && Vector3.Distance(transform.position, player.transform.position) < swallowableDistance)
            Destroy(gameObject);
    }


	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed);		
	}
}
