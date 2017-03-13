using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:ZakGray
public class AsteroidTest : MonoBehaviour {

    //Control asteroids in the environment

    public GameObject spawnLocation;//universal spawn anchor behind the camera
    public float spawnRate;//how often objects outside the despawn radius relocate
    public int spawnRadius;//where objects are moved to
    public int despawnRadius;//when objects move
    public float collisionRadius;//how much buffer objects must have when relocating

    private Transform spawnTransform;//spawn anchor transform
    private Vector3 rotation;//random rotation of asteroids

    void Start() {
        spawnTransform = spawnLocation.transform;//get spawn location
        rotation = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) / 3;//pick random rotation
    }
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs((float)transform.position.x - spawnTransform.position.x) >= despawnRadius || Mathf.Abs((float)transform.position.y - spawnTransform.position.y) >= despawnRadius)//if the asteroid is far enough away...
        {
            float spawnChance = Random.value;// random float 0-1
            if (spawnChance <= spawnRate)//Then if you have the chance to spawn
            {
                Vector2 spawnCircle = Random.insideUnitCircle.normalized * spawnRadius;//pick a random direction with vector length 1 multiplied by the spawn radius.
                Vector3 newSpawn = new Vector3(spawnTransform.position.x + spawnCircle.x, spawnTransform.position.y + spawnCircle.y, 15);//new spawn location is ship position plus spawn circle direction and 15 in z 
                                                                                                                                         //to offset spawn locaiton being behind the camera
                if (Physics.CheckSphere(newSpawn, collisionRadius) == false)//finally, if your new spawn is not in the middle of another object
                {
                    transform.position = newSpawn;//move to the new spot
                }
            }
        }
        transform.Rotate(rotation);//rotate
	}
    void OnCollsionEnter()//collider only here for physics check and ship collision. No trigger
    {

    }
}
