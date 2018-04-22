using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterballController : MonoBehaviour {

	public int attack;
	public float speed=0.01f;
	GameObject nearest;
    private Vector2 directrion;


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

	void Start () {
		nearest=FindnearestEnemy ();
		Vector2 EnermyPos = nearest.transform.position;
		Vector2 Myposi = transform.position;
		Vector2 direction = EnermyPos-Myposi;
        if ((EnermyPos - Myposi).magnitude < 100) {
			GetComponent<Rigidbody2D> ().velocity = speed * direction / Mathf.Abs(direction.magnitude);
		}


	}



	void Update () {
		//Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//		direction.Normalize ();


		Destroy (gameObject ,5.0f);
	}

    void SetDirection(Vector2 v) {
        directrion = v;
    }

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Respawn") {
			other.SendMessage ("WaterballHp", attack);
			Destroy (gameObject);
		} 
		else if (other.tag == "Wall") {
			Destroy (gameObject);
		}
	}
}
