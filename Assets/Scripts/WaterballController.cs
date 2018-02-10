using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterballController : MonoBehaviour {

	public float speed;
	void Update () {
		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 direction = (Vector2)((worldMousePos - transform.position));
//		direction.Normalize ();
		GetComponent<Rigidbody2D> ().velocity = speed * direction;

		Destroy (gameObject ,0.3f);
	}

	void onTriggerEnter2D () {
		Destroy (gameObject);
	}
}
