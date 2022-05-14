using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private List<GameObject> buidings = new List<GameObject>();

    private ModelForSale modelForSale;
    private Incom incom;
    private int lastBoughIndex =0 ;
    private bool oneBuldBought = false;

    public void Initialize(BuildingRepo buildingRepo)
    {
        modelForSale = GetComponentInChildren<ModelForSale>();
        incom = GetComponentInChildren<Incom>();

        for (var i = 0; i < buidings.Count; i++)
        {
            var isBought = SaveSystem.userData.boughtBuildings.Contains(buidings[i].name);

            if (isBought)
            {
                oneBuldBought = true;
                lastBoughIndex = i;

                //buidings[i].SetActive(true);

                //if (i > 0)
                //    buidings[i - 1].SetActive(false);


                //if (i >= buidings.Count - 1)
                //    modelForSale.gameObject.SetActive(false);
            }
            //else
            //{
            //    var info = buildingRepo.GetInfo(buidings[i].name);
            //    modelForSale.Init(buidings[i], info);

            //    return;
            //}
        }

        if(oneBuldBought)
        buidings[lastBoughIndex].SetActive(true);

        if ((lastBoughIndex + 1) < buidings.Count)
        {
            var info = buildingRepo.GetInfo(buidings[lastBoughIndex + 1].name);
            modelForSale.Init(buidings[lastBoughIndex + 1], info);
        }
        else 
        {
            modelForSale.gameObject.SetActive(false);
        }
    }

}
