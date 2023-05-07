using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudsVanish : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        cloud.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player") {
            Invoke("vanish",3f);
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag=="Player") {
            Invoke("appear",3f);
        }
    }
    void vanish(){
        cloud.SetActive(false);
    }
    void appear(){
        cloud.SetActive(true);
    }
}
