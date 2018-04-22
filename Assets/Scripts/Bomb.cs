using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    Animator anim;
    public float bomb_damage = 20f;
    public GameObject bounceBallPrefab;
    private GameObject up;
    private GameObject down;
    private GameObject left;
    private GameObject right;
    public float distance = 100f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.SendMessage("losehp", bomb_damage);
        }
        else
        {
            Destroy(other.gameObject);
        }
        anim.SetTrigger("hit");

        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length + 0.5f);

        up = (GameObject)Instantiate(bounceBallPrefab);
        down = (GameObject)Instantiate(bounceBallPrefab);
        left = (GameObject)Instantiate(bounceBallPrefab);
        right = (GameObject)Instantiate(bounceBallPrefab);
        up.transform.position = transform.position;
        up.SendMessage("SetDirection", new Vector3(0, distance, 0));
        down.transform.position = transform.position;
        down.SendMessage("SetDirection", new Vector3(0, -distance, 0));
        left.transform.position = transform.position;
        left.SendMessage("SetDirection", new Vector3(-distance, 0, 0));
        right.transform.position = transform.position;
        right.SendMessage("SetDirection", new Vector3(distance, 0, 0));
    }
}
