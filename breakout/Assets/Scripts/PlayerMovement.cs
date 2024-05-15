using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed; // Speed of the paddle movement

    float screenSize;

    private void Start()
    {
        screenSize = Camera.main.orthographicSize;

    }
    // Update is called once per frame
    void Update()
    {

        // Get input from arrow keys or A/D keys
        float moveInput = Input.GetAxis("Horizontal");

        // Calculate movement amount based on input and speed
        float moveAmount = moveInput * speed * Time.deltaTime;

        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(moveAmount, 0f, 0f);

        // Clamp the new position to prevent the paddle from going out of the screen
        newPosition.x = Mathf.Clamp(newPosition.x, -((screenSize * 2) - (this.gameObject.transform.localScale.x)), (screenSize * 2) - (this.gameObject.transform.localScale.x)); // Adjust these values according to your game's boundaries

        // Apply the new position to the paddle
        transform.position = newPosition;
    }
}
