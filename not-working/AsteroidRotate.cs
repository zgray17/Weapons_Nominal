using UnityEngine;
using System.Collections;

public class AsteroidRotate : Enemy {
	private int health;
	private int damage;
	private float size;
	private float speed;
	private Vector3 velocity;
	private Vector3 place = new Vector3(0,0,0);
	private int state;
	private float txPos;
	private float tyPos;
	private float angle;
	private float changeAngle;
	private float radius;

	// Use this for initialization
	void Start () {
		state = 0;
		place = transform.position;
		velocity = Main.spaceship.get_pos() - place;
		velocity.Normalize ();
		size = Random.Range (5, 11);
		speed = 1 / size;
		velocity *= speed;
		transform.localScale = new Vector3(size / 4, size / 4, size / 4);
	}

	// Update is called once per frame
	void Update () {
		if (state == 3) {
			transform.Translate (velocity);
			if ((Mathf.Abs (transform.position.x) > Main.xpos || Mathf.Abs (transform.position.y) > Main.ypos)) {
				gameObject.SetActive (false);
				DestroyImmediate (this);
			} else if ((Mathf.Abs ((transform.position - Main.spaceship.get_pos ()).magnitude) < size / 8 + .5)) {
				Main.spaceship.hit (this);
				gameObject.SetActive (false);
				DestroyImmediate (this);
			}
		} else if (state == 2){
			transform.Translate (velocity);
			if ((Mathf.Abs ((transform.position - Main.spaceship.get_pos ()).magnitude) < size / 8 + .5)) {
				Main.spaceship.hit (this);
				gameObject.SetActive (false);
				DestroyImmediate (this);
			}

			if ((transform.position - new Vector3(txPos, tyPos, 0)).magnitude >= 2*size/3 + 2) {
				state = 3;
				speed *= 2;
				velocity *= -2;
			}

		} else if (state == 1){
			angle += speed*Time.deltaTime;
			changeAngle += speed * Time.deltaTime;
			transform.position = new Vector3(Mathf.Cos (angle) * radius + txPos, Mathf.Sin (angle) * radius + tyPos, 0);

			if ( Mathf.Abs(changeAngle) >= Mathf.PI) {
				state = 2;
				speed = 1 / (2 * size);
				velocity = new Vector3(txPos - transform.position.x, tyPos - transform.position.y, 0).normalized * speed * -1;
			}


			if ((Mathf.Abs ((transform.position - Main.spaceship.get_pos ()).magnitude) < size / 8 + .5)) {
				Main.spaceship.hit (this);
				gameObject.SetActive (false);
				DestroyImmediate (this);
			}
				
		} else{
			transform.Translate (velocity);
			if ((Mathf.Abs (transform.position.x) > Main.xpos || Mathf.Abs (transform.position.y) > Main.ypos)) {
				gameObject.SetActive (false);
				DestroyImmediate (this);
			} else if ((Mathf.Abs ((transform.position - Main.spaceship.get_pos ()).magnitude) <= size /3 + 1)) {
				txPos = Main.spaceship.get_pos ().x;
				tyPos = Main.spaceship.get_pos ().y;
				state = 1;
				if (velocity.y > 0) {
					speed = - 1 * speed * (3 * Mathf.PI) * velocity.x / Mathf.Abs(velocity.x);
					angle = -1 * Mathf.Acos ((transform.position - Main.spaceship.get_pos ()).normalized.x);
				} else {
					speed =  speed * (3 * Mathf.PI) * velocity.x / Mathf.Abs(velocity.x);
					angle = Mathf.Acos ((transform.position - Main.spaceship.get_pos ()).normalized.x);
				}
				changeAngle = 0;

			    radius = size / 3 + 1;

			}
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
