using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonMove : MonoBehaviour
{
    public float spd; //speed of object
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * spd * Vector3.up);

    }
}
