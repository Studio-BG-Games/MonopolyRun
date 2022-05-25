using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    [SerializeField] private GameObject moneyExplosionPrefab;

    private int loss;

    public int Loss { get => loss; set => loss = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {
            if (other.gameObject.TryGetComponent<Picker>(out Picker player))
            {
                moneyExplosionPrefab.transform.SetParent(null);
                moneyExplosionPrefab.SetActive(true);
                player.LooseMoney(loss);
                gameObject.SetActive(false);
            }
            else
            {
                var policePos =this.gameObject.transform.position;
                policePos = (gameObject.transform.rotation.y ==90 || gameObject.transform.rotation.y == 270) ?
                    policePos + new Vector3(1,0,0) : policePos + new Vector3(0,0,1);
            }
        }
    }
}
