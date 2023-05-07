using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdFly : MonoBehaviour
{
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    } 
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Player") {//player health will decrease
    //         playerHealth.Instance.decreaseHealth();
    //     }
    // }
}
