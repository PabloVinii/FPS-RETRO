using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

    public Camera gameCamera;
    public GameObject impactEffect;
    public Animator WeaponAnimator;
    public Text ammoText;
    
    public int maxAmmo;
    public int currentAmmo;
    public int damageToApply;
    
    // Start is called before the first frame update
    void Start()
    {
        //bloqueia o mouse na tela
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "MUNIÇÃO\n" + currentAmmo;
        Fire();
    }
    
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentAmmo > 0)
            {  
                // um raio imaginario que sai do centro da tela, serve pra fazer o hit scan
                Ray ray = gameCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit raycastHited; 

                //verifica se acertou o local
                if (Physics.Raycast(ray, out raycastHited)) 
                // out serve para passar informação, se algo foi atingido o ray passa a info pro raycastHited
                //se ray acertou um objeto, out passa ao raycast que o nome do objeto
                {
                    Instantiate(impactEffect, raycastHited.point, raycastHited.transform.rotation);
                    Debug.Log("estou olhando para: " + raycastHited.transform.name);

                    //captura o gameobject e compara sua tag
                    if(raycastHited.transform.gameObject.CompareTag("Enemy"))
                    {
                        raycastHited.transform.gameObject.GetComponentInParent<Enemy>().DamageEnemy(damageToApply);
                    }
                }
                else
                {
                    Debug.Log("Não estou olhando nada");
                    
                }

                currentAmmo -= 1;
                ammoText.text = "MUNIÇÃO\n" + currentAmmo;
                WeaponAnimator.SetTrigger("Weapon Fire");
            }
            else
            {
                Debug.Log("Sem munição");
            }


        }
    }
}
