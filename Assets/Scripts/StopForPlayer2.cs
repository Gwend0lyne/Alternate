using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class StopForPlayer2 : MonoBehaviourPunCallbacks
{
    public GameObject saw;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            Debug.Log(saw);
            saw.GetComponent<SpriteRenderer>().color = new Color(0.634512f,0.5179334f,0.9716981f,0.7176471f);
         saw.GetComponent<rotate>().speed = 0f;
    saw.GetComponent<BoxCollider2D>().enabled = false;
            base.photonView.RPC("Stop", RpcTarget.Others);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            base.photonView.RPC("Respawn", RpcTarget.Others);
        }
    }

[PunRPC]
void Stop() 
{
    saw.GetComponent<SpriteRenderer>().color = new Color(0.634512f,0.5179334f,0.9716981f,0.7176471f);
    saw.GetComponent<rotate>().speed = 0f;
    saw.GetComponent<BoxCollider2D>().enabled = false;
}

[PunRPC]
void Respawn() 
{
    saw.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
    saw.GetComponent<rotate>().speed = 6.84f;
    saw.GetComponent<BoxCollider2D>().enabled = true;
}
}
