using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public int initialHealth, health, invinsibilityFrames;
    public GameObject healthBar;

    private int invinsible;
    private bool flash;
//player container handler
    void Start()
    {
        health = initialHealth;
        flash = true;
    }

    void Update()
    {
        if(invinsible > 0)
        {
            if (invinsible % 2 == 0)
            {
                flash = !flash;
                GameObject.Find("Ship").GetComponent<SpriteRenderer>().enabled = flash;
            }
        }
        else
        {
            GameObject.Find("Ship").GetComponent<SpriteRenderer>().enabled = true;
        }
        healthBar.transform.localScale = new Vector3(((float)health/(float)initialHealth),healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        invinsible--;
    }

    void OnTriggerEnter()//phsycal collisions with 3D objects
    {
        updateHealth();
    }

    public void updateHealth()
    {
        if (invinsible <= 0)
        {
            if (health > 1)
            {
                health--;
            }
            else
            {
                SceneManager.LoadScene("ThreePlayerScene");
            }
            invinsible = invinsibilityFrames;
        }
    }
}
