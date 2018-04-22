using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******** this file detects the player for enemes *********/

public class Vision : MonoBehaviour {

    private RaycastHit2D vision;
    private float rayLength;
    GameObject player;
    float moveSpeed = 0.02f;
    public bool haveSightOfPlayer = false;
    public float vision_distance = 10f;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        rayLength = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(gameObject.transform.position, player.transform.position, Color.red, 0.01f);

        int layermask = 1 << 8;
        vision = Physics2D.Raycast(gameObject.transform.position, player.transform.position - gameObject.transform.position, rayLength, layermask);

        if (vision.collider != null) {
            if (vision.collider.tag == "Player" && Vector2.Distance(gameObject.transform.position, player.transform.position) < vision_distance)
            {
                haveSightOfPlayer = true;
            }
            else {
                haveSightOfPlayer = false;
            }
        }
        
	}

}
