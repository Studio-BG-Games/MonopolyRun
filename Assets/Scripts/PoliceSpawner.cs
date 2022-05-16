using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    public void PoliceGenerator(PlayersFixation fixation, int loss)
    {
        for (var i = 0; i < fixation.Boundaries.Count; i++)
        {
            var police = Instantiate(Resources.Load("Prefabs/Police", typeof(Police))) as Police;
            police.gameObject.transform.position = FindPosition(fixation, i);
            police.gameObject.transform.Rotate(0, 90*i, 0);
            police.Loss = loss;
        }
    }

    private Vector3 FindPosition(PlayersFixation fixation,int areaOfPosition)
    {
        float xMin = fixation.Boundaries[areaOfPosition].xMin;
        float xMax = fixation.Boundaries[areaOfPosition].xMax;
        float zMin = fixation.Boundaries[areaOfPosition].zMin;
        float zMax = fixation.Boundaries[areaOfPosition].zMax;

        float xPos = Random.Range(xMin, xMax);
        float zPos = Random.Range(zMin, zMax);

        return new Vector3(xPos, 0, zPos);
    }
}
