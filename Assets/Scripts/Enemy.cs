using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemyVelocity;
    public Transform[] pointsToWalk;
    private int currentpoint;
    public bool enemyAlive;
    public bool enemyCanWalk;
    public float timeBetweenPoints;
    public float currentTime; 

    // Start is called before the first frame update
    void Start()
    {
        enemyAlive = true;
        enemyCanWalk = true;
        transform.position = pointsToWalk[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoviment();
    }

    private void EnemyMoviment()
    {
        if (enemyAlive == true)
        {
            if (enemyCanWalk == true)
            {   
                //mover para os pontos
                transform.position = Vector3.MoveTowards(transform.position, pointsToWalk[currentpoint].position, enemyVelocity * Time.deltaTime);
            
                if (transform.position.y == pointsToWalk[currentpoint].position.y)
                {
                    WaitToWalk();
                }

                if (currentpoint == pointsToWalk.Length)
                {
                    currentpoint = 0;
                }
            }

        }
    }

    private void WaitToWalk()
    {

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            //enemyCanWalk = true;
            currentpoint++;
            currentTime = timeBetweenPoints;
        }
    }
}
