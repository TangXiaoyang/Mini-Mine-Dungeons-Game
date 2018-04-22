using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperDoor : MonoBehaviour {

    private bool back = false;
    private Vector3 startPos;
    private Vector3 endPos;
    public float move_speed = 2f;
    public float move_distance = 2f;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, move_distance, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (!back)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endPos, move_speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPos) < 0.01)
            {
                back = !back;
            }
        }
        else {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, startPos, move_speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPos) < 0.01) {
                back = !back;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("losehp", 1000);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}
