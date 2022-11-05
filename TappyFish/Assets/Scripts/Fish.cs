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

    Animator anim;
    Rigidbody2D rb;
    public Score score;
    public GameManager gameManager;
    public SpawnManager spawnManager;

    [SerializeField]
    private AudioSource swim, hit, point;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
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
        if(Input.GetKeyDown(KeyCode.Space) && GameManager.gameOver == false)
        {
            if (GameManager.gameStarted == false)
            {
                rb.gravityScale = 3f;
                rb.velocity = Vector2.zero;
                gameManager.GameHasStarted();
                spawnManager.InstantiateObstacle();
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
            else
            {
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
            swim.Play();
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
                angle = angle - 8;
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
            point.Play();
            score.updateScore();
        }
        else if (collision.CompareTag("Column") && GameManager.gameOver == false)
        {
            FishDie();
            hit.Play();
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
                hit.Play();
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
