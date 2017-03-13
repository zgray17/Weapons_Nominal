using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zak Gray
public class WorldHandler : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 path = new Vector3(GameObject.Find("Player").GetComponent<Transform>().position.x - transform.position.x, GameObject.Find("Player").GetComponent<Transform>().position.y - transform.position.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, path, speed);
	}
}
