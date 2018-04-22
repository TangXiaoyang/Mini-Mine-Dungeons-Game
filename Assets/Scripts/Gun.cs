using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Gun : MonoBehaviour {

	public Transform firePoint;
	public GameObject waterball;
	GameObject closest;
	public Player evolevel;
    private Vector3 direction;

	public void shoot() {
		closest = FindnearestEnemy ();
        if (closest != null) {
            Vector2 Myposi = transform.position;
            Vector2 enemyposi = closest.transform.position;
            Vector2 enemyposi1 = enemyposi - Myposi;
            direction = Vector3.forward * (90 + Mathf.Atan2(Myposi.y - enemyposi.y, Myposi.x - enemyposi.x) * Mathf.Rad2Deg);//enemyposi - Myposi;


            Vector2 joyS = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
            //Debug.Log(joyS);
            //GameObject.FindGameObjectWithTag ("Respawn").SendMessage("WaterballHp");

            Ray2D ray = new Ray2D(firePoint.position, Input.mousePosition);
            float shotDistance = 5;
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, shotDistance);
            if (hit.collider != null)
            {
                shotDistance = hit.distance;
            }

            //		Debug.DrawRay (ray.origin, ray.direction * shotDistance, Color.red, 0.5f, true);
            //		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //		Vector2 direction = (Vector2)((worldMousePos - transform.position));
            //		direction.Normalize ();
            if ((enemyposi1 - joyS).magnitude < 5)
            {
                //Debug.Log ((enemyposi - Myposi).magnitude);
                for (int i = 0; i < evolevel.evolevel; i++)
                {
                    Invoke("generatebullet", 0.2f * i);
                }


            }
        }
	}

	void generatebullet(){
		Instantiate (waterball, 
			firePoint.position, 
			Quaternion.Euler(direction));
	}
		
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


}
