using Photon.Pun;
using Photon.Realtime;
using System.Net;
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
        photonView.RPC("StartCoinRotation", RpcTarget.AllBuffered, coin);

    }

    [PunRPC]
    private void StartCoinRotation(int coinResult)
    {
        DisplayResult(coinResult);

        Debug.Log("PunRPC has been called");

        newTest();

        CoinModelController.Instance.StartRotation(coinResult % 2 == 0 ? CoinModelController.Instance.tailsAngle : CoinModelController.Instance.headsAngle);
    }

    private void DisplayResult(int coinResult)
    {
        result.text = coinResult % 2 == 0 ? "Tails" : "Heads";
    }

    private void newTest()
    {
        string apiUrl = "http://18.233.82.156/";

        using (WebClient client = new WebClient())
        {
            string response = client.DownloadString(apiUrl);

            Debug.Log(response);
        }
    }
}
