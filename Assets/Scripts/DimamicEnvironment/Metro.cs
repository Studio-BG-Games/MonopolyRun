using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metro : MonoBehaviour
{
    private Transform metroOut;
    private int boundaryNumber;
    public Transform MetroOut { get => metroOut; set => metroOut = value; }
    public int BoundaryNumber { get => boundaryNumber; set => boundaryNumber = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Picker>(out Picker player))
        {
            player.UseMetro(metroOut, boundaryNumber);
        }
    }
}
