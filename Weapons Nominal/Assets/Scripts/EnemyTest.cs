using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {
    //Contoller for EnemyA
    public int speed;//movement speed
    public int spawnRadius;//spawn radius
    public int despawnRadius;//despawn radius
    public GameObject enemyContainer;

    private Transform spawnTransform;//universal spawn anchor behind the camera
    private Transform player;//player container
    private Transform enemyContainerTransform;

	void Start () {
     //get objects
        player = GameObject.Find("Player").transform;
        spawnTransform = GameObject.Find("spawnerLocation").transform;
        enemyContainerTransform = enemyContainer.transform;
    }
	
	void Update () {
        if (Mathf.Abs((float)transform.position.x - spawnTransform.position.x) >= despawnRadius || Mathf.Abs((float)transform.position.y - spawnTransform.position.y) >= despawnRadius)//if enemy is too far away from player...
        {
            newPosition();//move to new position
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.position, speed);//if you are not despawning, move toward the player
        }
        //this chunk points the enemy towards the player

        Vector3 vectorToTarget = player.position - transform.position;//determine the vector to the player
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;//turn the vector into an angle with MAAAAAATH
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);//math
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);//rotate enemy over time
    }

    void OnTriggerEnter2D(Collider2D col)//if you hit something
    {
        if (col.gameObject.tag == "Player")//if it doesnt have the tag of enemy it has crashed into the ship, a bullet, or an asteroid
        {
            newPosition();//move to new position
            col.GetComponent<ShipHandler>().shipHit();
        }
    }
    void OnCollisionEnter2D()//collider for no physical overlap
    {

    }

    public void newPosition()//find new position
    {
        Vector2 spawnCircle = Random.insideUnitCircle.normalized * spawnRadius;//pick a random spot on a circle of spawnRadius from the player
        Vector3 newSpawn = new Vector3(spawnTransform.position.x + spawnCircle.x, spawnTransform.position.y + spawnCircle.y, 15);//set the new spawn

        enemyContainerTransform.position = newSpawn;//move there
    }
}
