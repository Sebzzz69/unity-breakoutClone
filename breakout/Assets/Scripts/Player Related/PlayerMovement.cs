using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int speed; // Speed of the paddle movement

    float screenSize;

    public Animator animator;

    public float timerDuration = 1.0f;
    public bool shittery = false;

   /* public float runSpeed = 40f;
    float horizontalMove = 0f;*/


    private void Awake()
    {
        screenSize = Camera.main.orthographicSize;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(timerDuration);

        BallSwing();
        shittery = false;
    }

    private void BallSwing()
    {
        animator.SetBool("ballHit", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("jag hatar mitt fucking liv, snälla gör ett bättre movement script nästa gång även om det inte kommer bli en nästa gång. Jag hatar unity animation controller, jag hatar unity animation system, jag hatar mig själv. kl är 00:20 och jag vill bara vara klar med detta så jag känner mig uppfylld och tillräcklig till resten av personerna på projektet");
           
            animator.SetBool("ballHit", true);
            shittery = true;
        }
       
    }


    void PlaySwingAnimation()
    {
        if (animator != null)
        {
            animator.Play("PlayerSwing");

            Debug.Log("Swing anim");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shittery)
        {
            //StartCoroutine(TimerCoroutine());
            //animator.SetBool("ballHit", false);
            shittery = false;
            
        }

        // Get input from arrow keys or A/D keys
        float moveInput = Input.GetAxis("Horizontal");

        // Calculate movement amount based on input and speed
        float moveAmount = moveInput * speed * Time.deltaTime;

       


        #region Animation handler
        if (moveInput > 0)
        {
            gameObject.transform.localScale = Vector3.one;
            animator.Play("PlayerWalking");
            animator.SetBool("isRunning", true);
            animator.SetBool("ballHit", false);



        }
        else if (moveInput < 0) 
        {
            gameObject.transform.localScale = new Vector3 (-1, 1, 1);
            animator.Play("PlayerWalking");
            animator.SetBool("isRunning", true);
            animator.SetBool("ballHit", false);
        }
        else 
        {
            animator.SetBool("isRunning", false);

        }
        /*else
        {
            gameObject.transform.localScale = Vector3.one;
            animator.Play("PlayerIdle");
        }*/

        

        #endregion

        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(moveAmount, 0f, 0f);

        // Clamp the new position to prevent the paddle from going out of the screen
        newPosition.x = Mathf.Clamp(newPosition.x, -((screenSize * 2) - (this.gameObject.transform.localScale.x)), (screenSize * 2) - (this.gameObject.transform.localScale.x)); // Adjust these values according to your game's boundaries

        // Apply the new position to the paddle
        transform.position = newPosition;
    }


    


}
