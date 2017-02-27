using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainerHandler : MonoBehaviour {
    private Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(transform.position.x - player.position.x, transform.position.y - player.position.y) * -1);
    }

    void OnCollisionEnter()
    {

    }
}
