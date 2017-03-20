using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zak Gray
public class VortexScript : MonoBehaviour {

    public float vortexForce;
    public GameObject spawnLocation;//universal spawn anchor behind the camera
    public GameObject vortex;
    public float spawnRate;//how often objects outside the despawn radius relocate
    public int spawnRadius;//where objects are moved to
    public int despawnRadius;//when objects move
    public float collisionRadius;//how much buffer objects must have when relocating

    private Transform spawnTransform;//spawn anchor transform
    private List<GameObject> vortexObjects = new List<GameObject>();

    // Use this for initialization
    void Start () {
        spawnTransform = spawnLocation.transform;//get spawn location
    }
	// Update is called once per frame
	void Update () {
        foreach (GameObject vortexObject in vortexObjects)
        {
            if (vortexObject)
            {
                vortexObject.GetComponent<Rigidbody>().AddForce(new Vector3((float)transform.position.x - vortexObject.transform.position.x, (float)transform.position.y - vortexObject.transform.position.y) * vortexForce);
            }
        }

        if (Mathf.Abs((float)transform.position.x - spawnTransform.position.x) >= despawnRadius || Mathf.Abs((float)transform.position.y - spawnTransform.position.y) >= despawnRadius)//if the asteroid is far enough away...
        {
            float spawnChance = Random.value;// random float 0-1
            if (spawnChance <= spawnRate)//Then if you have the chance to spawn
            {
                Vector2 spawnCircle = Random.insideUnitCircle.normalized * spawnRadius;//pick a random direction with vector length 1 multiplied by the spawn radius.
                Vector3 newSpawn = new Vector3(spawnTransform.position.x + spawnCircle.x, spawnTransform.position.y + spawnCircle.y);//new spawn location is ship position plus spawn circle direction and 15 in z 
                                                                                                                                         //to offset spawn locaiton being behind the camera
                if (Physics.CheckSphere(newSpawn, collisionRadius) == false)//finally, if your new spawn is not in the middle of another object
                {
                    vortex.transform.position = newSpawn;//move to the new spot
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Background").GetComponent<Collider>());
        vortexObjects.Add(col.gameObject);
    }
    void OnTriggerExit(Collider col)
    {
        vortexObjects.Remove(col.gameObject);
    }
}
