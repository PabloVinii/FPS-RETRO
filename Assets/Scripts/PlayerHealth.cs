using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
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

            if(currentHealth <= 0)
            {
                GameManager.instance.GameOver();
            }
        }
    }

}
