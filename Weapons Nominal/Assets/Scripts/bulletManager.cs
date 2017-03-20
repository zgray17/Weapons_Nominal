﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zak Gray
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
        if (GetComponent<SpriteRenderer>().isVisible)
        {
            if (col.GetComponent<HitHandler>())
            {
                enemyScript = col.GetComponent<HitHandler>();
                enemyScript.Hit();
                transform.position = new Vector3(transform.position.x + 1000, transform.position.y + 1000);
            }
        }
        
    }

}