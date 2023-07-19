using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
        private int coin;
        private int i = 1;
        [SerializeField] private TextMeshProUGUI result;
        private GameObject coinModel;

    [SerializeField] private SpawnPlay spawnner;

        private CoinModelController coinModelController;

    PhotonView view;

    private void Start()
    {
        coinModel = spawnner.CoinSpawned;
        view = GetComponent<PhotonView>();
        coinModelController = coinModel.GetComponent<CoinModelController>();
    }

    private void Update()
    {
        if (coinModel == null) 
        {
            coinModel = GameObject.FindGameObjectWithTag("CoinModel");
           
        }
    }

    public void TossPressed()
        {
            coin = Random.Range(1, 100);

            DisplayResult();
            Debug.Log("Value of coin for " + i + "time: " + coin);
            i++;

            // Start the rotation based on the result of the coin toss
            if (coin % 2 == 0)
            {
                coinModelController.StartRotation(coinModelController.tailsAngle);
            }
            else
            {
                coinModelController.StartRotation(coinModelController.headsAngle);
            }
        }



        public void DisplayResult()
        {
            if (coin % 2 == 0)
            {
                result.text = "Tails";
            }
            else
            {
                result.text = "Heads";
            }
        }
}
