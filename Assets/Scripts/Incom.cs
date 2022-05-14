using TMPro;
using UnityEngine;

public class Incom : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;

    private int buildingIncom;

    public void Init(BuildInfo info)
    {
        buildingIncom = info.incom;
        playerNameText.text = $"$ {buildingIncom}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Picker>(out Picker player))
        {
            player.CollectMoney(buildingIncom);
            gameObject.SetActive(false);
        }
    }
}
