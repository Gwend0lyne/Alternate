using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTrough : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), transform.parent.GetComponent<BoxCollider2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), transform.parent.GetComponent<BoxCollider2D>(), false);
        }
    }
}
