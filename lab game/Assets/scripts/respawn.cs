using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class respawn : MonoBehaviour{
    public GameObject player;
    public GameObject controller;
    //public GameObject killzone;
    public Vector3 pos;
    // Start is called before the first frame update

    void Start()    
    {
        //pos= new Vector3(0.55f,2.63f,0.22f);
        pos= player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // playerHealth.Instance.decreaseHealth();
            // if(playerHealth.Instance.getHealth()==0){
            //     //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            //      Debug.Log("restarted");
            // }
            controller.GetComponent<scoreKeeper>().decreaseHealth();
            if(controller.GetComponent<scoreKeeper>().getHealth()==0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
                Debug.Log("restarted");
            }
            player.transform.position=new Vector3(pos.x,pos.y,pos.z);
        }
    }
}
