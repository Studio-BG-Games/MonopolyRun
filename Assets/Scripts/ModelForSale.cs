using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModelForSale : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;

    private string complexName;
    private string buldingName;
    private int coast;
   
    public void Init(string complex,GameObject model,BuildInfo info)
    {
        //Debug.Log($"{model.name}");
        var koef = info.reducingKoef;
       
        model.transform.localScale = new Vector3(koef, koef, koef);

        model.transform.SetParent(this.gameObject.transform);
        model.transform.localPosition = new Vector3(0, 0, 0);
        model.transform.localRotation = Quaternion.identity;
     
        model.gameObject.SetActive(true);
        complexName = complex;
        buldingName = model.name;

        coast = info.coast;
        playerNameText.text = $"$ {coast}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Picker>(out Picker player))
        {
            if (SaveSystem.userData.coins >= coast)
            {
                player.CollectBuilbings(complexName,buldingName, coast);
                gameObject.SetActive(false);
            }
        }
    }
}
