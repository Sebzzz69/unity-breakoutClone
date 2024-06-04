using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        // Get the Animator component attached to the player
        anim = GetComponent<Animator>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            PlaySwingAnimation();
        }
    }

    private void PlaySwingAnimation()
    {
        if (anim != null)
        {
            anim.Play("PlayerSwing");
            Debug.Log("Swing anim");
        }
    }
}
