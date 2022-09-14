using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float walkSpeed;
    public float jumpHeight;
    public float degree;
    public float deceleration;
    public float maxSpeed;
    public LayerMask mask;
    private float moveVelocity;
    Rigidbody2D rb;
    private bool _canJump;
    private float degreeVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        _canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Jump") > 0 && IsGrounded() && _canJump) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            _canJump = false;
            Invoke("setCanJump", 0.5f);
        }

        if(!IsGrounded()){
            if(Input.GetAxis("Vertical") != 0){
                if(Input.GetAxis("Vertical") > 0){
                    degreeVelocity -= degree;
                } else {
                    degreeVelocity += degree;
                }
                transform.eulerAngles = Vector3.forward * degreeVelocity;
            }
        }

        if(Input.GetAxis("Horizontal") != 0){
            if(Input.GetAxis("Horizontal") > 0){
                if(moveVelocity >= maxSpeed){
                    moveVelocity = maxSpeed;
                } else {
                    moveVelocity += walkSpeed;
                }
            } else {
                if(moveVelocity <= -(maxSpeed)){
                    moveVelocity = -(maxSpeed);
                } else {
                    moveVelocity -= walkSpeed;
                }

            }
        }
        if(moveVelocity > 2){
            moveVelocity -= deceleration;
        } else if (moveVelocity < -2){
            moveVelocity += deceleration;
        } else {
            moveVelocity = 0;
        }
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
    }

    void setCanJump() {
        this._canJump = true;
    }

    private bool IsGrounded() {
       var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, mask);
       return groundCheck.collider != null && groundCheck.collider.CompareTag("Ground");
    }
}
