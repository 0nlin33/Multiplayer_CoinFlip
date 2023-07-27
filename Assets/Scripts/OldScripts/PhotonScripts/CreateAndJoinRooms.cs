using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    //public int search=0;
    public void CreateRoom()
    {
       // search = 0;
       //PlayerPrefs.SetInt("search", 0);
        PhotonNetwork.CreateRoom(createInput.text); 
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        //search = 1;
        //PlayerPrefs.SetInt("search", 1);
        PhotonNetwork.LoadLevel("CoinFlip");
    }
}
