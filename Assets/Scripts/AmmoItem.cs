using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{   
    public int ammoToGive;
    public GameObject Weapon;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.CompareTag("DoubleBarrel"))
        {
            Weapon.gameObject.GetComponent<PlayerAttack>().ReloadAmmo(ammoToGive);
        }

        if(gameObject.CompareTag("Shotgun"))
        {
            Weapon.gameObject.GetComponent<PlayerAttack>().ReloadAmmo(ammoToGive);
        }

        if(gameObject.CompareTag("Pistol"))
        {
            Weapon.gameObject.GetComponent<PlayerAttack>().ReloadAmmo(ammoToGive);
        }
        Destroy(this.gameObject);
    }

}