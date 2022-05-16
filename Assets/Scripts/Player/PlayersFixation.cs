using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersFixation : MonoBehaviour
{
    [SerializeField] private float xMinBoundary, xMaxBoundary, zMinBoundary, zMaxBoundary;

    private List<Boundaries> boundaries = new List<Boundaries>();
    private float xMin, xMax, zMin, zMax;
    private float whide = 7f;

    public List<Boundaries> Boundaries { get => boundaries; set => boundaries = value; }

    public void Fixation(int i,Rigidbody rb)
    {
        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, Boundaries[i].xMin, Boundaries[i].xMax),
            1.0f,
            Mathf.Clamp(rb.position.z, Boundaries[i].zMin, Boundaries[i].zMax)
            );
    }
    public void FillList()
    {
        Boundaries.Add(new Boundaries(xMinBoundary, xMinBoundary + whide, zMinBoundary, zMaxBoundary));
        Boundaries.Add(new Boundaries(xMinBoundary, xMaxBoundary, zMaxBoundary - whide, zMaxBoundary));
        Boundaries.Add(new Boundaries(xMaxBoundary - whide, xMaxBoundary, zMinBoundary, zMaxBoundary));
        Boundaries.Add(new Boundaries(xMinBoundary, xMaxBoundary, zMinBoundary, zMinBoundary + whide));
    }
}
