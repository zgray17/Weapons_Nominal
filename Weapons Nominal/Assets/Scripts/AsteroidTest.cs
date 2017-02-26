using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTest : MonoBehaviour {

    public GameObject spawnLocation;
    public float spawnRate;
    public int spawnRadius;
    public int despawnRadius;
    public float collisionRadius;

    private Transform spawnTransform;
    private Vector3 rotation;

    void Start() {
        spawnTransform = spawnLocation.transform;
        rotation = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) / 3;
    }
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs((float)transform.position.x - spawnTransform.position.x) >= despawnRadius || Mathf.Abs((float)transform.position.y - spawnTransform.position.y) >= despawnRadius)
        {
            float spawnChance = Random.value;
            if (spawnChance <= spawnRate)
            {
                Vector2 spawnCircle = Random.insideUnitCircle.normalized * spawnRadius;
                Vector3 newSpawn = new Vector3(spawnTransform.position.x + spawnCircle.x, spawnTransform.position.y + spawnCircle.y, 15);
                if (Physics.CheckSphere(newSpawn, collisionRadius) == false)
                {
                    transform.position = newSpawn;
                }
            }
        }
        transform.Rotate(rotation);
	}
}
