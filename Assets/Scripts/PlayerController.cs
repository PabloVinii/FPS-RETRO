using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public Camera cameraDoJogo;

    public float playerSpeed;
    public float mouseSensitivity;
    private Vector2 keyboardInputs;
    private Vector2 mouseMovement;
    public Rigidbody2D playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovements();
        MoveCamera();
    }

    private void PlayerMovements()
    {
        //Pega os input das configurações do projeto
        keyboardInputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontalMoviment = transform.up * -keyboardInputs.x;
        Vector3 verticalMoviment = transform.right * keyboardInputs.y;

        //Movimento do Player
        playerRigidbody.velocity = (horizontalMoviment + verticalMoviment) * playerSpeed;
    }

    private void MoveCamera()
    {
        //Movimento do mouse
        mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * mouseSensitivity);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseMovement.x); 
        //Quaternion são os 4 eixos / Euler os converte para apenas 3


        //virar a camera na vertical, não sei vou usar ainda
        //cameraDoJogo.transform.localRotation = Quaternion.Euler(cameraDoJogo.transform.localRotation.eulerAngles + new Vector3(0f, mouseMovement.y, 0f));
 
    // limita o ângulo de rotação da câmera
 
        //cameraDoJogo.transform.localRotation = Quaternion.Euler(cameraDoJogo.transform.localRotation.eulerAngles.x, Mathf.Clamp(cameraDoJogo.transform.localRotation.eulerAngles.y, 2f, 120f), cameraDoJogo.transform.localRotation.eulerAngles.z);
    }
}
