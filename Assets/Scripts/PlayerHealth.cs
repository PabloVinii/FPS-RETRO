using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "VIDA\n" + currentHealth;
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
            healthText.text = "VIDA\n" + currentHealth;
            if(currentHealth <= 0)
            {
                GameManager.instance.GameOver();
            }
        }
    }

}
