using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growBalloon : MonoBehaviour
{
    [SerializeField] GameObject bigBalloon;
    [SerializeField] GameObject controller;
    [SerializeField] GameObject bound1, bound2;
    public AudioSource src;
    public float speed = 2.0f;
    private int direction = 1;
    private float timeBetweenDoingSomething = 1f;  //Wait 5 seconds after we do something to do something again
    private float timeWhenWeNextDoSomething;  //The next time we do something
    private const int requiredHit=10;
    public int count=0;
    void Start()
    {
        timeWhenWeNextDoSomething = Time.time + timeBetweenDoingSomething;
    }
    void Update () {
        if (transform.position.x > bound2.transform.position.x) {
            direction = -1;
        }
        else if (transform.position.x < bound1.transform.position.x) {
            direction = 1;
        }
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        if (timeWhenWeNextDoSomething <= Time.time){
            transform.localScale+= new Vector3(1,1,0);
            timeWhenWeNextDoSomething = Time.time + timeBetweenDoingSomething;
        }
        if(transform.localScale.x==50) Destroy(bigBalloon);
    } 

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Arrow"){
            count++;
            // scoreKeeper.Instance.addHit();
            // scoreKeeper.Instance.playerRowHits();
            controller.GetComponent<scoreKeeper>().addHit();
            controller.GetComponent<scoreKeeper>().playerRowHits();

            AudioSource.PlayClipAtPoint(src.clip, transform.position);
            
            if(count==requiredHit){
                // scoreKeeper.Instance.addBigBalloon();
                controller.GetComponent<scoreKeeper>().addBigBalloon();
                Destroy(bigBalloon);
                ScenesManager.Instance.LoadNextScene();
            }
            //scoreKeeper.Instance.UpdateScore();

            // if(count==hitRequired) 
        }
    }
}
