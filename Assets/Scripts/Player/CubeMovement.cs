using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float forceValue;
    [SerializeField] private float turnValue;
    [SerializeField] private Rigidbody rb;
    
    private PlayersFixation playersFixation;
    private float dir = 0;
    private bool isTurnOpen = false;
    private int boundaryNumber = 0;
    private Quaternion myRotation = Quaternion.identity;
    private float playerAngle = 0;

    public bool IsTurnOpen { get => isTurnOpen; set => isTurnOpen = value; }

    private void Update()
    {
        if (IsTurnOpen)
            RotatePlayer();

        playersFixation.Fixation(boundaryNumber, rb);
    }
    void FixedUpdate()
    {
        rb.velocity = (transform.forward + transform.right * dir) * forceValue;
    }

    public void Initialize(PlayersFixation _playersFixation)
    {
        playersFixation = _playersFixation;
        SwipeDetection.SwipeEvent += GetDirection;
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

        boundaryNumber++;
    }
    private void OnDisable()
    {
        SwipeDetection.SwipeEvent -= GetDirection;
    }
}

