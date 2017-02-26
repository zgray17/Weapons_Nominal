using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick : MonoBehaviour
{

    public bool isButton;
    public bool leftJoystick;
    public string buttonName;
    public GameObject controller;
    public GameObject bullet;
    public double velocity;
    public int fireRate;

    private Vector2 startPos;
    private Transform thisTransform;
    private MeshRenderer mr;
    private inputManager manager;
    private bool thisAButton;
    private Vector2 inputDirection;
    private Vector2 velocityVector;


    // Use this for initialization
    void Start()
    {
        thisTransform = transform;
        startPos = controller.transform.position + 2 * thisTransform.position;
        mr = this.GetComponent<MeshRenderer>();
        velocity = 0;
        fireRate = 10;
        Vector2 inputDirection = Vector2.zero;
        Vector2 velocityVector = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isButton)
        {
            //mr.enabled = Input.GetButton(buttonName);
            //parent.fireBullet();
        }
        else
        {
            if (leftJoystick)
            {
                thisTransform.rotation = Quaternion.LookRotation(new Vector2(Input.GetAxis("LeftJoystickHorizontal"), Input.GetAxis("LeftJoystickVertical")));
                if (Input.GetButton("SelectButton") && fireRate <= 0)
                {
                    inputDirection.x = Input.GetAxis("LeftJoystickHorizontal");
                    inputDirection.y = Input.GetAxis("LeftJoystickVertical");
                    //thisTransform.position = startPos + new Vector2(controller.transform.position.x, controller.transform.position.y);
                    // thisTransform.rotation = Quaternion.LookRotation(inputDirection);
                    velocityVector.x += -inputDirection.x * 2;
                    velocityVector.y += -inputDirection.y * 2;
                    fireRate = 15;
                    makeBullet();
                }
                else
                {
                    if (velocityVector != Vector2.zero)
                    {
                        velocityVector = velocityVector + new Vector2(-velocityVector.x / 50, -velocityVector.y / 50);
                    }
                }
            }



            else
            {
                thisTransform.rotation = Quaternion.LookRotation(new Vector2(Input.GetAxis("RightJoystickHorizontal"), Input.GetAxis("RightJoystickVertical")));
                if (Input.GetButton("AButton") && fireRate <= 0)
                {
                    inputDirection.x = Input.GetAxis("RightJoystickHorizontal");
                    inputDirection.y = Input.GetAxis("RightJoystickVertical");
                    //thisTransform.position = startPos + new Vector2(controller.transform.position.x, controller.transform.position.y);
                    // thisTransform.rotation = Quaternion.LookRotation(inputDirection);
                    velocityVector.x += -inputDirection.x * 2;
                    velocityVector.y += -inputDirection.y * 2;
                    fireRate = 15;
                    GameObject bullettemp;
                    bullettemp = Instantiate(bullet, thisTransform.position, thisTransform.rotation) as GameObject;
                }
                else
                {
                    if (velocityVector != Vector2.zero)
                    {
                        velocityVector = velocityVector + new Vector2(-velocityVector.x / 50, -velocityVector.y / 50);
                    }
                }
            }
        }
        controller.transform.position = controller.transform.position + new Vector3(velocityVector.x, velocityVector.y);
        fireRate--;
    }
    private void makeBullet()
    {
        Instantiate(bullet, thisTransform.position, thisTransform.rotation);
    }
}
