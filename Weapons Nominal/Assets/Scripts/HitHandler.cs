using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:KM

public enum Type { EnemyA, EnemyB, Object, ParentAsteroid, ChildAsteroid };//types of things bullets can interact with.


//Hit handler for anything that will be shot at
public class HitHandler : MonoBehaviour {

    public Type type;

    private EnemyTest enemyAScript;
    private ParentAsteroidHandler pah;
    private ChildAsteroidScript cas;

    void Start () {

	}
	
	void Update () {
       
    }
    public void Hit()
    {
        switch (type)
        {
            
            case Type.EnemyA:
                enemyAScript = GetComponent<EnemyTest>();
                enemyAScript.newPosition();
                GameObject.Find("Player").GetComponent<PlayerHandler>().updateScore();
                break;

            case Type.EnemyB:
                
                break;

            case Type.Object:

                break;

            case Type.ParentAsteroid:
                pah = GetComponent<ParentAsteroidHandler>();
                pah.spawnChildren();
                pah.newPosition();
                GameObject.Find("Player").GetComponent<PlayerHandler>().updateScore();
                break;

            case Type.ChildAsteroid:
                GameObject.Find("Player").GetComponent<PlayerHandler>().updateScore();
                cas = GetComponent<ChildAsteroidScript>();
                cas.SelfDestruct();
                break;

        }
    }
}
