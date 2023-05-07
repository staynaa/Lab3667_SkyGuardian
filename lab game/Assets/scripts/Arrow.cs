using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public float ArrowVel;
    [SerializeField] Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * ArrowVel;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="balloon") {
            Destroy(gameObject);
        }
    }
}
