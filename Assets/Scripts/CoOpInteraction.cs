using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class CoOpInteraction : MonoBehaviourPunCallbacks
{
    public GameObject firstCoOpPlatformToSpawn;
    public SpriteRenderer VisionPlatformForOtherPlayer;
    public GameObject saw2;
    private bool finishTouched = false;
    


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        // faire apparaitre la 1ere platform
        if(collision.gameObject.name == "first")
        {
            base.photonView.RPC("FristPlatformForPlayer1", RpcTarget.All, true );
        }
        // voir la plaform qui monte
        else if(collision.gameObject.name == "Vision1")
        {
            VisionPlatformForOtherPlayer.color = new Color(0.634512f,0.5179334f,0.9716981f,0.7176471f);
        }
        else if(collision.gameObject.name == "Reverse")
        {
            base.photonView.RPC("Reverse", RpcTarget.Others,true);
        }
        else if(collision.gameObject.name == "Stop")
        {
            base.photonView.RPC("StopSaw", RpcTarget.Others, false);
        }
        else if(collision.gameObject.name == "Next Stage Flag")
        {
            base.photonView.RPC("NextStage", RpcTarget.Others, true);
            finishTouched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.name == "first")
        {
            base.photonView.RPC("FristPlatformForPlayer1", RpcTarget.All, false );
        }
        else if(collision.gameObject.name == "Vision1")
        {
            VisionPlatformForOtherPlayer.color = new Color(0.634512f,0.5179334f,0.9716981f,0);
        }
        else if(collision.gameObject.name == "Reverse")
        {
            base.photonView.RPC("Reverse", RpcTarget.Others,false);
        }
        else if(collision.gameObject.name == "Stop")
        {
            base.photonView.RPC("StopSaw", RpcTarget.Others, true);
        }
        else if(collision.gameObject.name == "Next Stage Flag")
        {
            base.photonView.RPC("NextStage", RpcTarget.Others, false);
            finishTouched = false;
        }
    }

    [PunRPC]
    void FristPlatformForPlayer1 (bool shown) 
    {
        firstCoOpPlatformToSpawn.SetActive(shown);
    }

    [PunRPC]
    void Reverse(bool enter) 
    {
        
        if(enter){
            this. GetComponent<BoxCollider2D>().offset = new Vector2(0.05f, 0.27f);
            this.GetComponent<SpriteRenderer>().flipY = true;
            this.GetComponent<Rigidbody2D>().gravityScale = -2.1f;
            this.GetComponent<PlayerMovement>().reversed = -1;
        }
        else
        {
            this. GetComponent<BoxCollider2D>().offset = new Vector2(0.05f, -0.27f);
            this.GetComponent<SpriteRenderer>().flipY = false;
            this.GetComponent<Rigidbody2D>().gravityScale = 2.1f;
            this.GetComponent<PlayerMovement>().reversed = 1;
        }
        
    }

    [PunRPC]
    void StopSaw(bool active) 
    {
        saw2.SetActive(active);
    }

    

    [PunRPC]
    void NextStage(bool onColli) 
    {
        if (finishTouched == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        
    }
}
