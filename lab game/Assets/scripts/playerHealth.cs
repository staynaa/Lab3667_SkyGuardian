using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    private int health;
    // public static playerHealth Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        // if (Instance == null)
        // {
        //     DontDestroyOnLoad(this);
        //     Instance = this;
        //     Debug.Log("SET INSTANCE Health");
        // }
        // else
        // {
        //     Debug.Log("DESTROY health");
        //     Destroy(gameObject);
        // }
    }
    void Start()
    {
        health=3;
    }

    // Update is called once per frame
    void Update()
    {
        if(health==0){
            Debug.Log("GAME OVER");//restart scene
            health=3;
        }
    }
    public void decreaseHealth(){
        health--;
        // Debug.Log("Health: "+health);
    }
    public int getHealth(){
        return health;
    }
}
