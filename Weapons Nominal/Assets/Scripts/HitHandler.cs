using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zak Gray

public enum Type { EnemyA, EnemyB, Object };//types of things bullets can interact with.


//Hit handler for anything that will be shot at
public class HitHandler : MonoBehaviour {

    public Type type;

    private EnemyTest enemyAScript;

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
        }
    }
}
