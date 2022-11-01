using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rb;

    public int angle;
    public int minAngle = -20;
    public int maxAngle = 60;

    [SerializeField]
    private float speed;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8.0f;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(rb.velocity.x, speed);
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
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score.updateScore();
        }
    }

}
