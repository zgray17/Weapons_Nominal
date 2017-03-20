using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//Author:Zak Gray
public class VortexCenterScript : MonoBehaviour {

    public GameObject spawnLocation;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)//handle objects colliding with the center of the vortex
    {
      if(col.gameObject.tag == "Player")//reload scene is the player is sucked in;
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
      else//if no other criteria apply, treat as a basic enemy and move to new location
        {
            Vector2 spawnCircle = Random.insideUnitCircle.normalized * 200;//pick a random spot on a circle of spawnRadius from the player
            Vector3 newSpawn = new Vector3(spawnLocation.transform.position.x + spawnCircle.x, spawnLocation.transform.position.y + spawnCircle.y, 15);//set the new spawn

            col.transform.position = newSpawn;//move there
        }
    }
}
