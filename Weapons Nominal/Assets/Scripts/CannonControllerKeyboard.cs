//using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//Authors: Zak Gray, Jamie Schmidt
public class CannonControllerKeyboard : MonoBehaviour {

	public GameObject player;
	public GameObject bullet;
	public GameObject bulletEmitter;
	public GameObject spawnerLocation;
	public int fireRate;
	public int startX;
	public int startY;
    public float turnRate;
	public Animator anim;
	public KeyCode leftKeyboardInput;
	public KeyCode rightKeyboardInput;
	public KeyCode fireKeyboardInput;

	public AudioClip clip;

	public float scalefactor = 0.5f;

	private AudioSource audioSource;
	private Vector2 inputDirection;
	public static Vector2 velocityVector;
	public float angle;
	private bulletManager bulletManager;
	private Vector3 lastDir, nextDir;
	private int fire;


	GameObject[] bullets;
	int lastBullet = 0;
	int bulletCache = 30;

	// Use this for initialization
	void Start() {

		bullets = new GameObject[bulletCache];
		for (int i = 0; i < bulletCache; i++)
		{
			bullets[i] = Instantiate(bullet, spawnerLocation.transform.position, spawnerLocation.transform.rotation);
		}

		Vector2 inputDirection = Vector2.zero;
		Vector2 velocityVector = Vector2.zero;
		audioSource = GetComponent<AudioSource>();
		fire = fireRate;

		Vector3 nextDir = new Vector3(startX, startY, 0);
		lastDir = Vector3.zero;
		if (nextDir != Vector3.zero)
			angle = Mathf.Atan2(nextDir.y, nextDir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	// Update is called once per frame
	void Update() {


		Vector3 nextDir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) ;
		Debug.Log ("next" + nextDir);
		Debug.Log (angle);

		if (nextDir != Vector3.zero)
		{
			lastDir = nextDir;
			angle = Mathf.Atan2(nextDir.y, nextDir.x) * Mathf.Rad2Deg;
		}

		if (Input.GetKey(leftKeyboardInput)) 
		{
			Debug.Log ("left");
			angle -= turnRate;
		}
		if (Input.GetKey(rightKeyboardInput)) 
		{
			angle += turnRate;
		}
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       
        transform.rotation = Quaternion.Euler(0, 0, angle);
		if (Input.GetKey(fireKeyboardInput) && fire <= 0) 
		{
			if (nextDir != Vector3.zero)
			{
				velocityVector.x += -nextDir.x * scalefactor;
				velocityVector.y += -nextDir.y * scalefactor;
			}
			else
			{
				velocityVector.x += -lastDir.x * scalefactor;
				velocityVector.y += -lastDir.y * scalefactor;
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


        //move the object by applying a force to teh rigidbody of player
        GameObject.Find("Player").GetComponent<Rigidbody>().AddForce(velocityVector * scalefactor);
        fire--;
		if(Input.GetButton("SelectButton"))
		{
            LoadingScreenManager.LoadScene(0);
        }
        if (Input.GetKeyDown("escape"))
        {
            LoadingScreenManager.LoadScene(0);
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
