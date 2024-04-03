using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOnLanding : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "PlayerFoot")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.634512f,0.5179334f,0.9716981f,0.7176471f);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "PlayerFoot")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.634512f,0.5179334f,0.9716981f,0f);
        }
    }
}
