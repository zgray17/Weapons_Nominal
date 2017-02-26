using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {

    public int speed;
    public int spawnRadius;
    public int despawnRadius;

    private Transform spawnTransform;
    private Transform player;


	// Use this for initialization
	void Start () {
     
        player = GameObject.Find("Player").transform;
        spawnTransform = GameObject.Find("spawnerLocation").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs((float)transform.position.x - spawnTransform.position.x) >= despawnRadius || Mathf.Abs((float)transform.position.y - spawnTransform.position.y) >= despawnRadius)
        {
            newPosition();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        newPosition();
    }

    public void newPosition()
    {
        Vector2 spawnCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 newSpawn = new Vector3(spawnTransform.position.x + spawnCircle.x, spawnTransform.position.y + spawnCircle.y, 15);

        transform.position = newSpawn;
    }
}
