using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianZ : Pedestrian
{
    protected override void FindPosition()
    {
        var pos =  Random.Range(start.z, finish.z);

        transform.position = new Vector3(start.x, 0, pos);
    }
}
