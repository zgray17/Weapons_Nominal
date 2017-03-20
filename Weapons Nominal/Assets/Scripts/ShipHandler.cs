using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author:Zak Gray
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
    public void shipHit(int num)
    {
        playerHandler.updateHealth(num);
    }
}
