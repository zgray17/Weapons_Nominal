using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler : MonoBehaviour {
    //ship prefab handler
    private PlayerHandler playerHandler;
	void Start () {
        playerHandler = GameObject.Find("Player").GetComponent<PlayerHandler>();
	}
	
	void Update () {
		
	}

    void OnTrigger2DEnter()//Trigger when sprites collide with ship
    {
 
    }
    public void shipHit()
    {
        playerHandler.updateHealth();
    }
}
