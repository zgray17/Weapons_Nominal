using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Author:Zak Gray
public class PlayerHandler : MonoBehaviour
{
    public int initialHealth, health, invinsibilityFrames;
    public GameObject healthBar;
    public Text scorePanel;

    private int invinsible, score;
    private bool flash;
//player container handler
    void Start()
    {
        health = initialHealth;
        score = 0;
        scorePanel.text = score.ToString();
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

    void OnTriggerEnter(Collider col)//phsycal collisions with 3D objects
    {
        if (col.gameObject.tag != "IgnoreCollider")
        {
            updateHealth(-1);
        }
    }

    public void updateHealth(int healthUpdate)
    {
        if (invinsible <= 0)
        {
            if (health > 1)
            {
                health+= healthUpdate;
            }
            else
            {
                SceneManager.LoadScene("ThreePlayerScene");
            }
            invinsible = invinsibilityFrames;
        }
    }
    public void updateScore()
    {
        score++;
        scorePanel.text = score.ToString();
    }
}
