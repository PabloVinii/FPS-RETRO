using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //referencia ao objeto bullet
    public GameObject bullet;
    public Transform bulletPlace;
    public Transform[] pointsToWalk;
    private Animator animator;

    private int currentpoint;
    public int enemyMaxHealth;
    public int enemyCurrentHealth;

    public float enemyVelocity;
    public float distanceToAttack;
    public float timeBetweenAttacks;
    public float timeBetweenPoints;
    public float currentTime; 

    public bool enemyAttacked;
    public bool enemyAlive;
    public bool enemyCanWalk;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyAlive = true;
        enemyCanWalk = true;
        enemyAttacked = false;
        transform.position = pointsToWalk[0].position;
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.PlayerAlive)
        {
            EnemyMoviment();
            CheckDistance();
        }
        
    }

    private void EnemyMoviment()
    {
        if (enemyAlive == true)
        {
            if (enemyCanWalk == true)
            {   
                //mover para os pontos
                transform.position = Vector3.MoveTowards(transform.position, pointsToWalk[currentpoint].position, enemyVelocity * Time.deltaTime);
                if (transform.position.y != pointsToWalk[currentpoint].position.y)
                {
                    animator.SetTrigger("Walking");
                }
                
                if (transform.position.y == pointsToWalk[currentpoint].position.y)
                {
                    animator.SetTrigger("Idle");
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

    private void CheckDistance()
    {
        // mede a distancia do inimigo com o player
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < distanceToAttack)
        {
            AttackPlayer();
        }
        else
        {
            enemyCanWalk = true;
        }
    }

    private void AttackPlayer()
    {

        if (enemyAttacked == false && enemyAlive == true)
        {
            enemyCanWalk = false;
            animator.SetTrigger("Attack");
            Instantiate(bullet, bulletPlace.position, bulletPlace.rotation);
            enemyAttacked = true;
        
            //invocar chama um metodo de tanto em tanto tempo
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        enemyAttacked = false;
    }

    public void DamageEnemy(int damageToEnemy)
    {
        if (enemyAlive == true)
        {
            enemyCurrentHealth -= damageToEnemy;
            animator.SetTrigger("Damage");

            if (enemyCurrentHealth <= 0)
            {
                enemyAlive = false;
                enemyCanWalk = false;
                animator.SetTrigger("Death");
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponentInChildren<CapsuleCollider>().enabled = false;
            }
        }
    }

    public void EnemyDeath()
    {
        Destroy(this.gameObject);
    }

}
