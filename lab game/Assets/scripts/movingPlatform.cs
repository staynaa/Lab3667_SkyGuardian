using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
//     [SerializeField] GameObject platform;
    public float x1;
    public float x2;
//     public float speed = 100f;
//     public Vector3 pointA, pointB;

// void Start()
// {
//     pointA = new Vector3(x1, platform.transform.position.y, platform.transform.position.z);
//     pointB = new Vector3(x2, platform.transform.position.y, platform.transform.position.z);
// }

// void Update()
// {
//     float time = Mathf.PingPong(Time.time * speed, 1);
//     transform.position = Vector3.Lerp(pointA, pointB, time);
    
//     transform.Translate(Time.deltaTime * spd * Vector3.right);
// }
    public float speed = 2.0f;
    private int direction = 1;
 
    void Update () {
     if (transform.position.x > x2) {
         direction = -1;
     }
     else if (transform.position.x < x1) {
         direction = 1;
     }
     //movement = Vector3.right * direction * speed * Time.deltaTime; 
     transform.Translate(Vector3.right * direction * speed * Time.deltaTime); 
}
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            other.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            other.gameObject.transform.SetParent(null);
        }
    }
}
