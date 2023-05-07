using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject controller;
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 4;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;

    [SerializeField] Transform bowInHand;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null) rigid = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        if(!pauseMenu.isPaused)
        {movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump")) jumpPressed = true;
        rotateBow(); //bow moves where mouse tells it too
        }
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(SPEED * movement, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight) Flip();
        if (jumpPressed && isGrounded) Jump();
        else jumpPressed = false; 
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGrounded = true;
    }

    void rotateBow(){
        float angle= AngleTowardsMouse(bowInHand.position);
        bowInHand.rotation= Quaternion.Euler(new Vector3(0f,0f,angle+90)); //add 90 because we set z to 90 in the bows tranform
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bird") {//player health will decrease
            Debug.Log("Bird hurt me");
            controller.GetComponent<scoreKeeper>().decreaseHealth();
        }
    }
}