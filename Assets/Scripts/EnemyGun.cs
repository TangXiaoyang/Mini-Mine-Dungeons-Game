using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/************ this file initalize bullets of enemies ***********/

public class EnemyGun : MonoBehaviour {

	public Transform firePoint;
	public GameObject waterball;
    public float shootDistance = 5;
	

	public void shoot() {
		Vector2 Myposi = firePoint.position;
		Vector2 playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
        if ((Myposi - playerPos).magnitude < shootDistance) {
			Instantiate (waterball, 
				firePoint.position,
                firePoint.rotation);
		}

		
	}


}
