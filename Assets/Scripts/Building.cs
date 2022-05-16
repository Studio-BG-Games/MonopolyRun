using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private List<GameObject> buidings = new List<GameObject>();
    [SerializeField] private Incom incom;

    private ModelForSale modelForSale;
   
    public void Initialize(BuildingRepo buildingRepo)
    {
        modelForSale = GetComponentInChildren<ModelForSale>();

        var buildCollection = SaveSystem.userData.boughtBuildings;

        var isBought = buildCollection.ContainsKey(this.gameObject.name);

        if (isBought)
        {
            for (var i = 0; i < buidings.Count; i++)
            {
                var actualName = buidings[i].name;
                if (buildCollection.ContainsValue(actualName))
                {
                    buidings[i].SetActive(true);
                    InitIncomModel(i, buildingRepo);
                    InitModelForSale(i+1, buildingRepo);

                    return;
                }
            }
        }
        else
        {
            InitModelForSale(0, buildingRepo);
        }
    }

    private void InitModelForSale(int i ,BuildingRepo buildingRepo)
    {
        var info = buildingRepo.GetInfo(buidings[i].name);
        modelForSale.Init(this.gameObject.name, buidings[i], info);
    }
    private void InitIncomModel(int i,BuildingRepo buildingRepo)
    {
        var info = buildingRepo.GetInfo(buidings[i].name);
        incom.Init(info);
    }
}
