using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CubeMovement : MonoBehaviour
{
    [SerializeField] private PlayersFixation playersFixation;
    [SerializeField] private float forceValue;
    [SerializeField] private float turnValue;
 
    private Rigidbody rb;
    private float dir = 0;
    private bool isTurnOpen = false;
    private int number = 0;
    private Quaternion myRotation;
    private float playerAngle = 0;

    public bool IsTurnOpen { get => isTurnOpen; set => isTurnOpen = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SwipeDetection.SwipeEvent += GetDirection;

        myRotation = Quaternion.identity;

        playersFixation.FillList();
    }

    private void Update()
    {
        if (IsTurnOpen)
            RotatePlayer();

        playersFixation.Fixation(number, rb);
    }
    void FixedUpdate()
    {
        rb.velocity = (transform.forward + transform.right * dir) * forceValue;
    }

    private void GetDirection(Vector3 direction)
    {
        if (direction.x == 0)
            dir = 0;

        else
            dir = direction.x < 0 ? -1 : 1;
    }

    private void RotatePlayer()
    {

        if (transform.rotation.eulerAngles.y < myRotation.eulerAngles.y)
        {
            float singleStep = turnValue * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, transform.right, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            isTurnOpen = false;
            transform.rotation = myRotation;
        }
    }

    public void ChangeDirection()
    {
        playerAngle += 90;
        myRotation.eulerAngles = new Vector3(0, playerAngle, 0);

        number++;
    }
}

