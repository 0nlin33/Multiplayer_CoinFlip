using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlay : MonoBehaviour
{
    public GameObject play;

    public GameObject CoinSpawned;


    private void Start()
    {
        Vector3 randomPos = new Vector3(0, 0, 175);
        CoinSpawned = PhotonNetwork.Instantiate(play.name, randomPos, Quaternion.identity);
    }

}
