using Photon.Pun;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviourPun
{
    private int coin;
    private int i = 1;
    [SerializeField] private TextMeshProUGUI result;

    PhotonView view;

    [SerializeField] private GameObject coinPrefab; // Assign the Coin prefab in the Inspector.

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        Vector3 randomPos = new Vector3(0, 0, 175);
        PhotonNetwork.Instantiate(coinPrefab.name, randomPos, Quaternion.identity);
    }

    public void TossPressed()
    {
        coin = Random.Range(1, 100);

        DisplayResult(coin);
        Debug.Log("Value of coin for " + i + "time: " + coin);
        i++;

        // Start the rotation based on the result of the coin toss
        photonView.RPC("StartCoinRotation", RpcTarget.All, coin);

    }

    [PunRPC]
    private void StartCoinRotation(int coinResult)
    {
        DisplayResult(coinResult);

        Debug.Log("PunRPC has been called");

        CoinModelController.Instance.StartRotation(coinResult % 2 == 0 ? CoinModelController.Instance.tailsAngle : CoinModelController.Instance.headsAngle);
    }

    private void DisplayResult(int coinResult)
    {
        result.text = coinResult % 2 == 0 ? "Tails" : "Heads";
    }
}
