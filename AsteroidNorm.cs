using UnityEngine;
using System.Collections;

public class AsteroidNorm : Enemy {
	private int health;
	private int damage;
	private float size;
	private float speed;
	private Vector3 velocity;
	private Vector3 place;

	public AsteroidNorm(){
		
	}


	// Use this for initialization
	void Start () {
		place = transform.position;
		velocity = -1 * place;
		velocity = velocity + new Vector3(Random.Range(-20, 21), Random.Range(-10, 11), 0);
		velocity.Normalize ();
		size = Random.Range (5, 11);
		speed = 1 / (size * 2);
		velocity *= speed;
		transform.localScale = new Vector3(size / 4, size / 4, size / 4);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (velocity);
		if ((Mathf.Abs (transform.position.x) > Main.xpos || Mathf.Abs (transform.position.y) > Main.ypos)) {
			gameObject.SetActive (false);
			DestroyImmediate (this);
		} else if ((Mathf.Abs ((transform.position - Main.spaceship.get_pos ()).magnitude) < size / 8 + .5)) {
			Main.spaceship.hit (this);
			gameObject.SetActive (false);
			DestroyImmediate (this);
		}
	}

	public override double getX(){
		return transform.position.x;
	}

	public override double getY(){
		return transform.position.y;
	}

	public override Vector3 getPos(){
		return transform.position;
	}

	public override float getSize(){
		return size;
	}
}
