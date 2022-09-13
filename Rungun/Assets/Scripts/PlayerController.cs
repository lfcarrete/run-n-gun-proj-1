using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float walkSpeed;
    public float jumpHeight;
    public LayerMask mask;
    private float moveVelocity;
    Rigidbody2D rb;
    private bool _canJump;
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
            Invoke("setCanJump", 0.8f);
        }

        moveVelocity = 0;
        if(Input.GetAxis("Horizontal") != 0){
            if(Input.GetAxis("Horizontal") > 0){
                moveVelocity += walkSpeed;
            } else {
                moveVelocity -= walkSpeed;
            }
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
