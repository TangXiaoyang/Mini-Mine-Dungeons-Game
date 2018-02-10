using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public Transform firePoint;
	public GameObject waterball;

	//system

	public void shoot() {
		Ray2D ray = new Ray2D (firePoint.position,Input.mousePosition);
		float shotDistance = 5;
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, shotDistance);
		if (hit.collider != null) {
			shotDistance = hit.distance;
		}
//		Debug.DrawRay (ray.origin, ray.direction * shotDistance, Color.red, 0.5f, true);
//		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		Vector2 direction = (Vector2)((worldMousePos - transform.position));
//		direction.Normalize ();
		Instantiate (waterball, 
					firePoint.position, 
					firePoint.rotation);
	}


}
