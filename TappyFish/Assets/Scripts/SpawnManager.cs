using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;

    float timer, randPosY;
    public float maxTime, maxY, minY;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = 3.5f;
        minY = -2.25f;
        maxY = 0.5f;
        InstantiateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver == false)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                randPosY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }
    }

    void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randPosY);

    }
}
