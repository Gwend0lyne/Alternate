using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class OnlyToPlayer2 : MonoBehaviour
{
    public BoxCollider2D boxCollider1;
    public BoxCollider2D boxCollider2;
    public SpriteRenderer VisionPlatformForPlayer2;

    void Start()
    {

        if(PhotonNetwork.IsMasterClient)
        {
            //enlever collision
            boxCollider1.enabled= false;
            boxCollider2.enabled= false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!PhotonNetwork.IsMasterClient&&other.gameObject.name == "PlayerFoot")
        {
            VisionPlatformForPlayer2.color = new Color(0.634512f,0.5179334f,0.9716981f,0.7176471f);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(!PhotonNetwork.IsMasterClient&&other.gameObject.name == "PlayerFoot")
        {
            VisionPlatformForPlayer2.color = new Color(0.634512f,0.5179334f,0.9716981f,0f);
        }
    }

}
