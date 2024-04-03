using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // la box qui fait que le haut mais pas les cotes on l'a mit en trigger pour la differencier 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.transform.SetParent(transform);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.transform.SetParent(null);
            
        }
    }
}
