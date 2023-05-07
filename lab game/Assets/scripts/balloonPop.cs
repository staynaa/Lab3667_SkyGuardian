using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonPop : MonoBehaviour
{
    public GameObject UiObject;
    public GameObject trigger;
    public AudioSource src;
    public GameObject controller;
    //scoreKeeper sk;

    public int hitRequired; //required amount of times to hit the balloons to pop base on difficulty chosen
    public int count=0;
    // Start is called before the first frame update
    void Start()
    
    {
        // controller=UiObject.FindWithTag("controller");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Arrow"){ 
            // count++;
            // scoreKeeper.Instance.addHit();
            // scoreKeeper.Instance.playerRowHits();
            // scoreKeeper.Instance.UpdateScore();
            controller.GetComponent<scoreKeeper>().scoringProcess();
            AudioSource.PlayClipAtPoint(src.clip, transform.position);
            Destroy(UiObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
