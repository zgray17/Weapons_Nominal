using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zak Gray
public class EnemyContainerHandler : MonoBehaviour {

    public float speed;

    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(transform.position.x - player.position.x, transform.position.y - player.position.y) / -speed);
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
    }

    void OnCollisionEnter()
    {

    }
}
