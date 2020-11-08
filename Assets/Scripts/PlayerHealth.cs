using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerHealth : MonoBehaviourPun, IPunObservable
{
    private float health = 100.0f;
    public float Health {
        get {
            return health;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            stream.SendNext(health);
        }
        if (stream.IsReading) {
            health = (float)stream.ReceiveNext();
        }
    }

    private void Update() {
        if (health <= 0f) {
            if (GameManager.Instance.isGameOver == false)
                GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!photonView.IsMine) return;
        if (other.name.Contains("Bullet")) {
            BulletManager bm = other.GetComponent<BulletManager>();
            health -= 10.0f;
            Debug.Log("Health " + health);
            bm.DestroyRequest();
        }
    }
}
