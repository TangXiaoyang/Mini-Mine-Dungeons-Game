using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepValley : MonoBehaviour {

    public float x;
    public float y;
    public float damage;
    float z;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        z = player.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            player.SendMessage("Teleport", new Vector3(x, y, z));
            player.SendMessage("losehp", damage);
        }
        else if(other.tag == "Respawn"){
            Destroy(other.gameObject);
        }
    }
}
