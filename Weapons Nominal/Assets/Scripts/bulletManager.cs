using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
 
    //Manager bullet operations

    private HitHandler enemyScript;

    public void start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector2.right) * 4);//move bullet
    }

    void OnTriggerEnter2D(Collider2D col)//when hitting something do things
    {
        if (col.GetComponent<HitHandler>())
        {
            enemyScript = col.GetComponent<HitHandler>();
            enemyScript.Hit();
        }
    }

}