using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int speed; // Speed of the paddle movement

    float screenSize;

    Animator animator;


    private void Awake()
    {
        screenSize = Camera.main.orthographicSize;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        // Get input from arrow keys or A/D keys
        float moveInput = Input.GetAxis("Horizontal");

        // Calculate movement amount based on input and speed
        float moveAmount = moveInput * speed * Time.deltaTime;




        #region Animation handler
        if (moveInput > 0)
        {
            gameObject.transform.localScale = Vector3.one;
            animator.Play("PlayerWalking");
        }
        else if (moveInput < 0) 
        {
            gameObject.transform.localScale = new Vector3 (-1, 1, 1);
            animator.Play("PlayerWalking");
        }
        else
        {
            gameObject.transform.localScale = Vector3.one;
            animator.Play("PlayerIdle");
        }
        #endregion

        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(moveAmount, 0f, 0f);

        // Clamp the new position to prevent the paddle from going out of the screen
        newPosition.x = Mathf.Clamp(newPosition.x, -((screenSize * 2) - (this.gameObject.transform.localScale.x)), (screenSize * 2) - (this.gameObject.transform.localScale.x)); // Adjust these values according to your game's boundaries

        // Apply the new position to the paddle
        transform.position = newPosition;
    }


    public void HandlePowerUp(string powerUpType)
    {
        // Logic for what happens when the player picks up a power-up
        switch (powerUpType)
        {
            case "Speed":
                // Increase player speed
                break;
            case "Health":
                // Increase player health
                break;
                // Add more cases for different types of power-ups as needed
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("psps");
            animator.Play("PlayerSwing");
        }
    }


}
