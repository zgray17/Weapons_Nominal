using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
 
    private Transform thisTransform;
    private Transform shipTransform;
    private Vector2 startPos;
    private Vector3 velocityVector;
    private EnemyTest enemyScript;

    public void start()
    {
        thisTransform = transform;
        startPos = thisTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector2.right + new Vector2(velocityVector.x * 50, velocityVector.y * 50)) * 4);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        enemyScript = col.GetComponent<EnemyTest>();
        enemyScript.newPosition();
    }

}