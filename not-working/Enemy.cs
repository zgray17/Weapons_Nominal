using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public abstract double getX ();
	public abstract double getY ();
	public abstract Vector3 getPos();
	public abstract float getSize();
}
