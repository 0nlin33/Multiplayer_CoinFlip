using Photon.Pun;
using UnityEngine;
using System.Collections;

public class CoinFlipHost : MonoBehaviourPun
{
    public GameObject coinPrefab; // Assign the Coin prefab in the Inspector.

    private bool isFlipping = false;

    private void Start()
    {
        // Spawn the Coin GameObject if the local player owns this GameObject.
        if (photonView.IsMine)
        {
            Vector3 randomPos = new Vector3(0, 0, 175);
            PhotonNetwork.Instantiate(coinPrefab.name, randomPos, Quaternion.identity);
        }
    }

    public void FlipCoin()
    {
        if (photonView.IsMine && !isFlipping)
        {
            // Call the custom network message to start the coin flip.
            photonView.RPC("StartCoinFlip", RpcTarget.All);
        }
    }

    [PunRPC]
    private void StartCoinFlip()
    {
        if (coinPrefab != null)
        {
            CoinModelController coinModelController = coinPrefab.GetComponent<CoinModelController>();
            if (coinModelController != null)
            {
                StartCoroutine(FlipCoinAnimation(coinModelController));
            }
        }
    }

    private IEnumerator FlipCoinAnimation(CoinModelController coinModelController)
    {
        isFlipping = true;

        // Randomly choose the angle to flip the coin (headsAngle or tailsAngle).
        float targetAngle = Random.Range(0f, 360f);

        // Flip the coin animation by rotating it.
        float duration = 1.5f;
        float elapsedTime = 0f;
        float startAngle = coinModelController.transform.eulerAngles.y;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            coinModelController.transform.rotation = Quaternion.Euler(0f, Mathf.Lerp(startAngle, targetAngle, t), 0f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the coin ends up with the correct angle.
        coinModelController.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        isFlipping = false;
    }
}
