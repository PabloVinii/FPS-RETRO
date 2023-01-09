using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour
{
    public bool healthItem;
    public bool goldenKey;
    public bool silverKey;
    public int ammoToGive;
    public int lifeToGive;
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {

            if(healthItem == true)
            {
                if (other.gameObject.GetComponent<PlayerHealth>().currentHealth != other.gameObject.GetComponent<PlayerHealth>().maxHealth)
                {
                    other.gameObject.GetComponent<PlayerHealth>().AddLife(lifeToGive);
                    Destroy(this.gameObject);
                }      
            }

            if(goldenKey == true)
            {
                GameManager.instance.isGoldenkey = true;
                Destroy(this.gameObject);
            }

            if(silverKey == true)
            {
                GameManager.instance.isSilverkey= true;
                Destroy(this.gameObject);            
            }
            
        }
    }
}
