using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModelForSale : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;

    private string buldingName;
    private int cost;
   
    private void Start()
    {
       
    }
    public void Init(GameObject model,float koef)
    {
        model.transform.localScale = new Vector3(koef, koef, koef);

        model.transform.SetParent(this.gameObject.transform);
        model.transform.localPosition = new Vector3(0, 0, 0);
        model.transform.localRotation = Quaternion.identity;
        //model.transform.localRotation = Quaternion.Euler(0, -90, 0);
        model.gameObject.SetActive(true);

        buldingName = model.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Picker>(out Picker player))
        {
            player.CollectBuilbings(buldingName, cost);
        }
    }
}
