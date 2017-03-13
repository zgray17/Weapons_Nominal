using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zak Gray
public class VortexScript : MonoBehaviour {

    public float vortexForce;

    private List<GameObject> vortexObjects = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        foreach (GameObject vortexObject in vortexObjects)
        {
            vortexObject.GetComponent<Rigidbody>().AddForce(new Vector3((float)transform.position.x - vortexObject.transform.position.x, (float)transform.position.y - vortexObject.transform.position.y) * vortexForce);
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
