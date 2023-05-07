using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shotArrow : MonoBehaviour
{
[SerializeField] GameObject arrowObject, bowObject;
[SerializeField] Animator bowAnimator;
[SerializeField] SpriteRenderer ArrowGFX;
[SerializeField] Transform bow;
[SerializeField] bool CanFire;
public GameObject controller;
//scoreKeeper sk;
public int amountShot;

// public int ammo=10; //amount of arrows player starts game with
    void Start()
    {
        bowAnimator=bowObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (!pauseMenu.isPaused)
        {CanFire=true;
        // else Debug.Log("Out of arrows");
        if(Input.GetMouseButtonDown(0)){
            bowAnimator.SetTrigger("shoot_bow");// play shooting animation when mouse click
        }
        if(Input.GetMouseButtonUp(0) && CanFire){
            bowAnimator.SetTrigger("stand");
            fireBow();
            //scoreKeeper.Instance.ShotsFired(); //call shots fired to keep track of shots that have been fired
            controller.GetComponent<scoreKeeper>().ShotsFired();
        }
        }
    }
    void fireBow(){
        float arrowSpeed=10f;
        float angle=AngleTowardsMouse(bow.position);
        Quaternion rot= Quaternion.Euler(new Vector3(0f,0f,angle-90));
        Arrow arrowObj= Instantiate(arrowObject, bow.position, rot).GetComponent<Arrow>();
        arrowObj.ArrowVel=arrowSpeed;
        //ammo--;
        CanFire= false; 
    }
    public float AngleTowardsMouse(Vector3 pos){
        Vector3 mousePos= Input.mousePosition;
        mousePos.z=5.23f;
        Vector3 objPos = Camera.main.WorldToScreenPoint(pos);
        mousePos.x=mousePos.x-objPos.x;
        mousePos.y=mousePos.y-objPos.y;

        float angle= Mathf.Atan2(mousePos.y,mousePos.x)*Mathf.Rad2Deg;

        return angle;
    }
}
