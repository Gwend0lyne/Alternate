using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ReverseForPlayer1 : MonoBehaviourPunCallbacks
{
    public GameObject player;
    // Start is called before the first frame update
    //player.GetComponent<Rigidbody2D>().gravityScale = 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            base.photonView.RPC("Inverse", RpcTarget.Others);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            base.photonView.RPC("Inverse", RpcTarget.Others);
        }
    }

    [PunRPC]
    void Inverse() 
    {
        player.GetComponent<Rigidbody2D>().gravityScale = -1f*player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<SpriteRenderer>().flipY = !player.GetComponent<SpriteRenderer>().flipY;
    }

}
