using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletManager : MonoBehaviourPun
{
    public void DestroyRequest() {
        photonView.RPC("Destroy", photonView.Owner);
    }

    [PunRPC]
    private void Destroy() {
        if (photonView.IsMine) {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
