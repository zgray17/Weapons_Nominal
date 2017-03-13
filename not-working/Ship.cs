using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	private int speed;


	// Use this for initialization
	void Start () {
		speed = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (new Vector3 (0, -1 * speed * Time.deltaTime, 0));
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		} 
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (new Vector3 (-1 * speed * Time.deltaTime, 0, 0));
		}
	}

	public void hit(Enemy hitter){
	}

	public Vector3 get_pos(){
		return transform.position;
	}
}
