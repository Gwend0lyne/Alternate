using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnlyPlayer1 : MonoBehaviour
{
    public BoxCollider2D boxCollider1;
    public BoxCollider2D boxCollider2;
    public SpriteRenderer VisionPlatformForPlayer2;

    void Start()
    {

        if(!PhotonNetwork.IsMasterClient)
        {
            //enlever collision
            boxCollider1.enabled= false;
            boxCollider2.enabled= false;
            VisionPlatformForPlayer2.color = new Color(0.634512f,0.5179334f,0.9716981f,0.7176471f);
        }

    }
}
