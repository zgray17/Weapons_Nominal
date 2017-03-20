using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour {

    public bool AButton;
    public bool BButton;
    public bool XButton;
    public bool YButton;
    public bool LeftBumper;
    public bool RightBumper;
    public bool SelectButton;
    public bool StartButton;
    public float LeftJoystickHorizontal;
    public float LeftJoystickVertical;
    public float RightJoystickHorizontal;
    public float RightJoystickVertical;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        AButton = Input.GetButton("AButton");
        BButton = Input.GetButton("BButton");
        XButton = Input.GetButton("XButton");
        YButton = Input.GetButton("YButton");
        LeftBumper = Input.GetButton("LeftBumper");
        RightBumper = Input.GetButton("RightBumper");
        SelectButton = Input.GetButton("SelectButton");
        StartButton = Input.GetButton("StartButton");
        LeftJoystickHorizontal = Input.GetAxis("LeftJoystickHorizontal");
        LeftJoystickVertical = Input.GetAxis("LeftJoystickVertical");
        RightJoystickHorizontal = Input.GetAxis("RightJoystickHorizontal");
        RightJoystickVertical = Input.GetAxis("RightJoystickVertical");
    }
    public bool getAButton()
    {
        return AButton;
    }
    public void test()
    {
        Debug.Log("test");
    }

}
