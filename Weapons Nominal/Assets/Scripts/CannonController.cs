using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//Author: Zakary Gray
public class CannonController : MonoBehaviour {
    public GameObject player;
    public GameObject bullet;
    public GameObject bulletEmitter;//location just in front of cannon to spawn bullets
    public GameObject spawnerLocation;//universal spawn location at 0,0 behind the camera
    public int fireRate;
    public int startX;//used for initial direction of cannon
    public int startY;//^^^
    public Animator anim;
    public string fireButton;//set control scheme
    public string joystickVertical;//^^^
    public string joystickHorizontal;//^^^
    public AudioClip clip;
    public float bulletForce;

    private AudioSource audioSource;
    private Vector2 inputDirection;//input from controller joystick
    private Vector2 velocityVector;
    public float angle;
    private bulletManager bulletManager;//script in bullet prefabs "fired" from cannons
    private Vector3 lastDir;//used to save last direction of input is input is zero
    private int fire;//used to control firerate
    
    //Bullet pool system so that each cannon reuses bullet prefabs after they have been fired as to not create too many bullets
    private GameObject[] bullets;
    private int lastBullet = 0;
    public int bulletCache = 10;

    // Use this for initialization
    void Start() {
        //create bullet pool
        bullets = new GameObject[bulletCache];
        for (int i = 0; i < bulletCache; i++)
        {
            bullets[i] = Instantiate(bullet, spawnerLocation.transform.position, spawnerLocation.transform.rotation);
        }
        //initial fire directions are zero
        Vector2 inputDirection = Vector2.zero;
        Vector2 velocityVector = Vector2.zero;
        //establish audio
        audioSource = GetComponent<AudioSource>();
        //fire rate established from input in inspector
        fire = fireRate;
        //rotate cannons to starting position
        Vector3 NextDir = new Vector3(startX, startY, 0);
        lastDir = Vector3.zero;
        if (NextDir != Vector3.zero)
            angle = Mathf.Atan2(NextDir.y, NextDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Update is called once per frame
    void Update() {
        //get direction of corrosponding joystick from controller
        Vector3 NextDir = new Vector3(Input.GetAxis(joystickHorizontal), Input.GetAxis(joystickVertical), 0);
        if (NextDir != Vector3.zero)
        {
            lastDir = NextDir;
            angle = Mathf.Atan2(NextDir.y, NextDir.x) * Mathf.Rad2Deg;//find the angle using MATH!
        }
        //rotate cannon
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //handle fire button being pressed
        if (Input.GetButton(fireButton) && fire <= 0)//if you press the button and fire is low enough
        {
            if (NextDir != Vector3.zero)//update fire direction
            {
                velocityVector.x += -NextDir.x * 2;
                velocityVector.y += -NextDir.y * 2;
            }
            else
            {
                velocityVector.x += -lastDir.x * 2;
                velocityVector.y += -lastDir.y * 2;
            }
            fire = fireRate;//reset fire
            makeBullet();
            anim.Play("fire");//play sprite animation
            audioSource.PlayOneShot(clip);//play gunfire sound
        }
        else
        {
            if (velocityVector != Vector2.zero)//if you are moving
            {
                velocityVector = velocityVector + new Vector2(-velocityVector.x / 50, -velocityVector.y / 50);//a dampening force is applied
            }
        }
        //move the object by applying a force to teh rigidbody of player
        GameObject.Find("Player").GetComponent<Rigidbody>().AddForce(velocityVector * bulletForce);
        //fire ticks down to regulate firing rate of bullets
        fire--;
        //pressing select on any controller goes back to the menu
        if(Input.GetButton("SelectButton"))
        {
            SceneManager.LoadScene("Menu");
        }
    } 
    
    void makeBullet()//used to "make" bullets. bullets are moved to the bullet emmiter and move forward with their new direction
    {
        int bulletNumber = GetNextBullet();//return the next bullet in the list
        bullet = bullets[bulletNumber];//get that bullet prefab
        bullet.transform.position = bulletEmitter.transform.position;//set to new position
        bullet.transform.rotation = bulletEmitter.transform.rotation;//set to new rotation
    }
    
    int GetNextBullet()//itterates to the next bullet int he list
    {
        lastBullet += 1;
        if (lastBullet > bulletCache - 1)
        {
            lastBullet = 0;//reset the loop
        }
        return lastBullet;
    }
}

