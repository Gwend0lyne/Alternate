using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class NextStage : MonoBehaviourPunCallbacks
{
    private bool levelCompleted = false;
    public int applesToHave;
    public GameObject player;
    private ItemCollector itemCollector;

    private void Start()
    {
        // le son de fin
        itemCollector = player.GetComponent<ItemCollector>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(itemCollector.appleCounter+"");
        if(other.gameObject.name == "Player"&& !levelCompleted&& itemCollector.appleCounter == applesToHave)
        {
            Debug.Log("itemCollector.appleCounter");
            levelCompleted = true;
            //base.photonView.RPC("PlayersGoNextStage",RpcTarget.All);
            Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel()
    {
        //Attend 1 sec quand on l'appelle
        //base.photonView.RPC("PlayersGoNextStage",RpcTarget.All);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

/*
    [PunRPC]
    private void PlayersGoNextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }*/

}
