using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    public GameObject ship;

    private Transform thisTransform;
    private Transform shipTransform;
    private Vector2 startPos;
    private Vector3 velocityVector;

    public void start()
    {
        thisTransform = transform;
        startPos = thisTransform.position;
        shipTransform = ship.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector2.right + new Vector2(velocityVector.x*50, velocityVector.y*50))*4);
    }

    public void shipSpeed(Vector3 shipSpeed)
    {
        velocityVector = shipSpeed;
    }
}

