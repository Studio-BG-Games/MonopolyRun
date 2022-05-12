using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private List<GameObject> buidings;
    [SerializeField] private ModelForSale modelForSale;
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        for (var i = 0; i < buidings.Count; i++)
        {
            Debug.Log($"{buidings[i].name}");
            //logic if it is bought 
            if (true)
            {
                modelForSale.Init(buidings[2], 0.07f);

                if (i > 0)
                    buidings[i-1].SetActive(true);

                return;
            }
        }
    }
}
