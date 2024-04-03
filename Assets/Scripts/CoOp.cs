using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CoOp : MonoBehaviour
{
    public GameObject player1Panel;
    public GameObject player2Panel;

    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            player1Panel.SetActive(true);
            player2Panel.SetActive(false);
            
        }
        else{
            player1Panel.SetActive(false);
            player2Panel.SetActive(true);
        }
    }


}
