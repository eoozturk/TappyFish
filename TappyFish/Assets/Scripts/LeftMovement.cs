using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    private float speed, groundWidth, obsWidth;

    BoxCollider2D groundBox;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;

        if (gameObject.CompareTag("Ground"))
        {
            groundBox = GetComponent<BoxCollider2D>();
            groundWidth = groundBox.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obsWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }

  
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.bottomLeft.x -  obsWidth)
            {
                Destroy(gameObject);
            }
        }
    }
}
