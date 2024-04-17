using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    Rigidbody2D rb;
    [SerializeField] float speed;


    private void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke(nameof(SetRandomTrajectory), 1);
    }

    void SetRandomTrajectory()
    {
        Vector2 direction = Vector2.zero;
        direction.x = Random.Range(-1f, 1f);
        direction.y = -1f;

        this.rb.AddForce(direction.normalized * this.speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 direction = Vector2.zero;
            direction.x = Random.Range(-1f, 1);
        }
    }

}
