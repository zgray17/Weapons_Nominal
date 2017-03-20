using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAsteroidScript : MonoBehaviour
{
    //private Vector3 velocityVector;
    public float speed;
    public int despawnRadius;
    public GameObject container;

    private Transform spawnTransform;//universal spawn anchor behind the camera
    private Transform player;//player container
    private Vector3 vectorToTarget;


    // Use this for initialization
    void Start()
    {
        spawnTransform = GameObject.Find("spawnerLocation").transform;
        //transform.localScale = new Vector3();
        //velocityVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) / 3;

    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs((float)transform.position.x - spawnTransform.position.x) >= despawnRadius || Mathf.Abs((float)transform.position.y - spawnTransform.position.y) >= despawnRadius)//if enemy is too far away from player...
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D col)//if you hit something
    {
        if (col.gameObject.tag == "Player")//if it doesnt have the tag of enemy it has crashed into the ship, a bullet, or an asteroid
        {
            col.GetComponent<ShipHandler>().shipHit(-1);
            Destroy(this.gameObject);
        }
    }

    public void SelfDestruct()
    {
        Destroy(container);
    }

}