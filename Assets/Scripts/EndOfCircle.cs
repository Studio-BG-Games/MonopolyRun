using System;
using System.Collections;
using UnityEngine;

public class EndOfCircle : MonoBehaviour
{
    [SerializeField] private GameObject confettiPrefab;

    public Action OnReloadScene;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<CubeMovement>();
        if (player != null)
        {
            StartCoroutine(TheEnd(player.gameObject.transform));
        }
    }

    private IEnumerator TheEnd(Transform playerPos)
    {
        confettiPrefab.transform.position = playerPos.position;
        confettiPrefab.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.7f);
        OnReloadScene?.Invoke();
    }
}
