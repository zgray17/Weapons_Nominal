using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	public Transform asteroidNorm;
	public Transform asteroidSeek;
	public Transform asteroidRotate;
	public Transform asteroidBlock;
	public Transform asteroidHome;
	public Transform asteroidTrail;
	public Ship target;
	public static Ship spaceship;
	public static int xpos;
	public static int ypos;


	void Start (){
		spaceship = target;
		xpos = 24;
		ypos = 14;

//		for (int i = 0; i < 100; i++) {
//			int randomThing = Random.Range (1, 5);
//			if (randomThing == 1) {
//				Instantiate (asteroidNorm, new Vector2 (-24, Random.Range (-11, 11)), Quaternion.identity);
//			} else if (randomThing == 2) {
//				Instantiate (asteroidNorm, new Vector2 (24, Random.Range (-11, 11)), Quaternion.identity);
//			} else if (randomThing == 3) {
//				Instantiate (asteroidNorm, new Vector2 (Random.Range (-22, 22), 12), Quaternion.identity);
//			} else {
//				Instantiate (asteroidNorm, new Vector2 (Random.Range (-22, 22), -12), Quaternion.identity);
//			}
//		}

//		for (int i = 0; i < 100; i++) {
//			int randomThing = Random.Range (1, 5);
//			if (randomThing == 1) {
//				Instantiate (asteroidSeek, new Vector2 (-24, Random.Range (-11, 11)), Quaternion.identity);
//			} else if (randomThing == 2) {
//				Instantiate (asteroidSeek, new Vector2 (24, Random.Range (-11, 11)), Quaternion.identity);
//			} else if (randomThing == 3) {
//				Instantiate (asteroidSeek, new Vector2 (Random.Range (-22, 22), 12), Quaternion.identity);
//			} else {
//				Instantiate (asteroidSeek, new Vector2 (Random.Range (-22, 22), -12), Quaternion.identity);
//			}
//		}

//		Instantiate (asteroidBlock, new Vector2 (-10, 10), Quaternion.identity);
//		Instantiate (asteroidRotate, new Vector2 (10, 10), Quaternion.identity);

//		Instantiate (asteroidHome, new Vector2 (-10, 10), Quaternion.identity);
		Instantiate (asteroidTrail, new Vector2 (-10, 10), Quaternion.identity);
		Instantiate (asteroidBlock, new Vector2 (10, 10), Quaternion.identity);
		Instantiate (asteroidBlock, new Vector2 (-10, -10), Quaternion.identity);
		Instantiate (asteroidBlock, new Vector2 (-10, 10), Quaternion.identity);
		Instantiate (asteroidBlock, new Vector2 (10, -10), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
