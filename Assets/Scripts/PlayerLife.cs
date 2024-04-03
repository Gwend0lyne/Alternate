using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PlayerLife : MonoBehaviourPunCallbacks
{
    private Rigidbody2D rb;
    private Animator anim;
    private ItemCollector itemCollector;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        itemCollector = GetComponent<ItemCollector>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Traps"))
        {
            base.photonView.RPC("Die",RpcTarget.All);
        }
    }
    
    [PunRPC]
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        itemCollector.appleCounter = 0;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload notre scene
    }
}
