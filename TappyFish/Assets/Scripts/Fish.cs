using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    public int angle;
    bool groundConrol;
    public int minAngle = -20;
    public int maxAngle = 60;
    
    [SerializeField]
    private float speed;

    Rigidbody2D rb;
    public Score score;
    public Animator anim;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8.0f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();
    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if(GameManager.gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
        }
    }

    void FishRotation()
    {
        if(rb.velocity.y > 0)
        {
            if(angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        if(groundConrol == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            FishDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score.updateScore();
        }
        else if (collision.CompareTag("Column"))
        {
            FishDie();
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                FishDie();
                gameManager.GameOver();
            }
        }
    }

    void FishDie()
    {
        groundConrol = true;
        anim.enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }

}
