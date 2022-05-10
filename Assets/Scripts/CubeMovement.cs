using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float forceValue;
    [SerializeField] private float turnValue;
    [SerializeField] private float xMinBoundary, xMaxBoundary, zMinBoundary, zMaxBoundary;

    private Rigidbody rb;
    private float dir = 0;
    private List<Boundaries> boundaries = new List<Boundaries>();
    private float xMin, xMax, zMin, zMax;
    private float whide = 7f;
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

        FillList();
    }

    private void Update()
    {
        if (IsTurnOpen)
            RotatePlayer();

        Fixation(number);
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

    private void Fixation(int i)
    {
        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundaries[i].xMin, boundaries[i].xMax),
            1.0f,
            Mathf.Clamp(rb.position.z, boundaries[i].zMin, boundaries[i].zMax)
            );
    }
    private void FillList()
    {
        boundaries.Add(new Boundaries(xMinBoundary, xMinBoundary + whide, zMinBoundary, zMaxBoundary));
        boundaries.Add(new Boundaries(xMinBoundary, xMaxBoundary, zMaxBoundary - whide, zMaxBoundary));
        boundaries.Add(new Boundaries(xMaxBoundary - whide, xMaxBoundary, zMinBoundary, zMaxBoundary));
        boundaries.Add(new Boundaries(xMinBoundary, xMaxBoundary, zMinBoundary, zMinBoundary + whide));
    }
    public void ChangeBounbaries()
    {
        playerAngle += 90;
        myRotation.eulerAngles = new Vector3(0, playerAngle, 0);

        number++;
    }
}

