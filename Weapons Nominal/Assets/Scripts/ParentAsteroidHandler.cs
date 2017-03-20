using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ParentAsteroidHandler : MonoBehaviour
{
    //Contoller for a breakable asteroid
    public float speed;
    public int spawnRadius;
    public int despawnRadius;
    public GameObject enemyContainer;
    public bool spawnChildrenImpact;
    public GameObject childAsteroid;
    public float childSpawn;


    private Transform spawnTransform;//universal spawn anchor behind the camera
    private Transform player;//player container
    private Transform enemyContainerTransform;
    private Vector3 vectorToTarget;


    void Start()
    {
        //get objects
        player = GameObject.Find("Player").transform;
        spawnTransform = GameObject.Find("spawnerLocation").transform;
        enemyContainerTransform = enemyContainer.transform;
        vectorToTarget = player.position - transform.position;//determine the vector to the player
    }

    void Update()
    {
        if (Mathf.Abs((float)transform.position.x - spawnTransform.position.x) >= despawnRadius || Mathf.Abs((float)transform.position.y - spawnTransform.position.y) >= despawnRadius)//if enemy is too far away from player...
        {
            newPosition();//move to new position
        }

        //this chunk points the enemy towards the player
        Rigidbody rb = enemyContainer.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(enemyContainerTransform.position.x - player.position.x, enemyContainerTransform.position.y - player.position.y) / -speed);
        Physics.IgnoreCollision(enemyContainer.GetComponent<Collider>(), player.GetComponent<Collider>());//dont collide with the player

    }

    void OnTriggerEnter2D(Collider2D col)//if you hit something
    {
        if (col.gameObject.tag == "Player")//if it doesnt have the tag of enemy it has crashed into the ship, a bullet, or an asteroid
        {
            newPosition();//move to new position
            col.GetComponent<ShipHandler>().shipHit(-5);
            
            if (spawnChildrenImpact)
            {
                spawnChildren();
            }
            
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
        Vector3 vectorToTarget = player.position - transform.position;//determine the vector to the player
    }

    public void spawnChildren()
    {
        for (int i = 0; i<5; i++)
        {
            //Scaling to account for the enemy swarm container

            GameObject child = Instantiate(childAsteroid, transform.position,transform.rotation);
            child.transform.localScale = new Vector3(1F, 1F);
            Rigidbody rb = child.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(Random.insideUnitCircle.normalized * childSpawn);

        }
    }

}
