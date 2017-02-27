using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public int health;
    public Text healthText;
//player container handler
    void Start()
    {
        health = 20;
        healthText.text = health.ToString();
    }

    void Update()
    {
        healthText.text = health.ToString();
    }

    void OnTriggerEnter()//phsycal collisions with 3D objects
    {
        updateHealth();
    }

    public void updateHealth()
    {
        if(health>0)
        {
            health--;
        }
        else
        {
            SceneManager.LoadScene(2);   
        }
    }
}
