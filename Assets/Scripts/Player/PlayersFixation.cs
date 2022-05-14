using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersFixation : MonoBehaviour
{
    [SerializeField] private float xMinBoundary, xMaxBoundary, zMinBoundary, zMaxBoundary;

    private List<Boundaries> boundaries = new List<Boundaries>();
    private float xMin, xMax, zMin, zMax;
    private float whide = 7f;

    
    public void Fixation(int i,Rigidbody rb)
    {
        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundaries[i].xMin, boundaries[i].xMax),
            1.0f,
            Mathf.Clamp(rb.position.z, boundaries[i].zMin, boundaries[i].zMax)
            );
    }
    public void FillList()
    {
        boundaries.Add(new Boundaries(xMinBoundary, xMinBoundary + whide, zMinBoundary, zMaxBoundary));
        boundaries.Add(new Boundaries(xMinBoundary, xMaxBoundary, zMaxBoundary - whide, zMaxBoundary));
        boundaries.Add(new Boundaries(xMaxBoundary - whide, xMaxBoundary, zMinBoundary, zMaxBoundary));
        boundaries.Add(new Boundaries(xMinBoundary, xMaxBoundary, zMinBoundary, zMinBoundary + whide));
    }
}
