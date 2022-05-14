using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
     private Building[] buildings  = new Building[0];

    public void CollectBuilding()
    {
        buildings = this.gameObject.GetComponentsInChildren<Building>();
    }
    public void SetBuildings(BuildingRepo buildingRepo)
    {
        foreach (var item in buildings)
        {
            item.Initialize(buildingRepo);
        }
    }
}
