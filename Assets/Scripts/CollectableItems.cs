using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour
{
    public bool ammoItem;
    public bool healthItem;
    public bool goldenKey;
    public bool silverKey;
    public int ammoToGive;
    public int lifeToGive;
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if(ammoItem == true)
            {
            
            }

            if(healthItem == true)
            {
            
            }

            if(goldenKey == true)
            {
            
            }

            if(silverKey == true)
            {
            
            }
            Destroy(this.gameObject);
        }
    }
}
