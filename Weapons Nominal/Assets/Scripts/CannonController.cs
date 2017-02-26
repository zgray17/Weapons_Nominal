using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CannonController : MonoBehaviour {
    public GameObject player;
    public GameObject bullet;
    public GameObject bulletEmitter;
    public GameObject spawnerLocation;
    public int fireRate;
    public int startX;
    public int startY;
    public Animator anim;
    public string fireButton;
    public string joystickVertical;
    public string joystickHorizontal;
    public AudioClip clip;

    private AudioSource audioSource;
    private Vector2 startPos;
    private Transform thisTransform;
    private Vector2 inputDirection;
    private Vector2 velocityVector;
    public float angle;
    private bulletManager bulletManager;
    private Vector3 lastDir;
    private int fire;
    
    GameObject[] bullets;
    int lastBullet = 0;
    int bulletCache = 10;

    // Use this for initialization
    void Start() {

        bullets = new GameObject[bulletCache];
        for (int i = 0; i < bulletCache; i++)
        {
            bullets[i] = Instantiate(bullet, spawnerLocation.transform.position, spawnerLocation.transform.rotation);
        }

        thisTransform = transform;
        startPos = player.transform.position + 2 * thisTransform.position;
        Vector2 inputDirection = Vector2.zero;
        Vector2 velocityVector = Vector2.zero;
        audioSource = GetComponent<AudioSource>();
        fire = fireRate;

        Vector3 NextDir = new Vector3(startX, startY, 0);
        lastDir = Vector3.zero;
        if (NextDir != Vector3.zero)
            angle = Mathf.Atan2(NextDir.y, NextDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Update is called once per frame
    void Update() {
        
        Vector3 NextDir = new Vector3(Input.GetAxis(joystickHorizontal), Input.GetAxis(joystickVertical), 0);
        if (NextDir != Vector3.zero)
        {
            lastDir = NextDir;
            angle = Mathf.Atan2(NextDir.y, NextDir.x) * Mathf.Rad2Deg;
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (Input.GetButton(fireButton) && fire <= 0)
        {
            if (NextDir != Vector3.zero)
            {
                velocityVector.x += -NextDir.x * 2;
                velocityVector.y += -NextDir.y * 2;
            }
            else
            {
                velocityVector.x += -lastDir.x * 2;
                velocityVector.y += -lastDir.y * 2;
            }
            fire = fireRate;
            makeBullet();
            anim.Play("fire");
            audioSource.PlayOneShot(clip);
        }
        else
        {
            if (velocityVector != Vector2.zero)
            {
                velocityVector = velocityVector + new Vector2(-velocityVector.x / 50, -velocityVector.y / 50);
            }
        }
        player.transform.position = player.transform.position + new Vector3(velocityVector.x, velocityVector.y) /20;
        fire--;
        if(Input.GetButton("SelectButton"))
        {
            SceneManager.LoadScene("Menu");
        }
    } 
    
    void makeBullet()
    {
        Debug.Log("test");
        int bulletNumber = GetNextBullet();
        bullet = bullets[bulletNumber];
        bullet.transform.position = bulletEmitter.transform.position;
        bullet.transform.rotation = bulletEmitter.transform.rotation;
    }
    
    int GetNextBullet()
    {
        lastBullet += 1;
        if (lastBullet > bulletCache - 1)
        {
            lastBullet = 0;//reset the loop
        }
        return lastBullet;
    }
}

