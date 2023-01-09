using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool PlayerAlive;
    public bool isGoldenkey;
    public bool isSilverkey;
    

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isGoldenkey = false;
        isSilverkey = false;
        PlayerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        PlayerAlive = false;
        Debug.Log("Game Over");
    }
}
