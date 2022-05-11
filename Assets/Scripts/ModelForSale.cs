using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModelForSale : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private float yRotate;

    public GameObject model;

    private void Start()
    {
        Init(model);
    }
    public void Init(GameObject model)
    {
      
       model.transform.rotation = Quaternion.Euler(0, 90, 0);
        model.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        model.transform.SetParent(this.gameObject.transform);
        model.transform.localPosition = new Vector3(0, 0, 0);
    }
}
