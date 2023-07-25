using Photon.Pun;
using UnityEngine;

public class CoinFlipClient : MonoBehaviourPun
{
    public void OnFlipButtonClick()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null /*&& gameManager.photonView.IsMine*/)
        {
            Debug.Log("Coin Toss Pressed on this system, OnFlipButtonClick function called.");
            gameManager.TossPressed();
        }
    }
}
