using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ItemCollector : MonoBehaviourPunCallbacks
{
    public int appleCounter = 0;
    [SerializeField] private Text appleText;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            base.photonView.RPC("SetAll", RpcTarget.All, (int)1 );
        }
    }

[PunRPC]
void SetAll (int apple) 
{
	appleCounter = appleCounter + apple;
    appleText.text = ""+appleCounter;
}
}
