using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damageToPlayer)
    {
        if(GameManager.instance.PlayerAlive == true)
        {
            currentHealth -= damageToPlayer;
            healthBar.SetHealth(currentHealth);

            if(currentHealth <= 0)
            {
                GameManager.instance.GameOver();
            }
        }
    }

    public void AddLife(int lifeToAdd)
    {
        if (currentHealth + lifeToAdd < maxHealth)
        {
            currentHealth += lifeToAdd;
        }
        else
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
    }

}
