using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class PlayerController : MonoBehaviour {
    public Object player;
    public float walkSpeed;
    public float jumpHeight;
    public float degree;
    public float maxSpeed;
    public LayerMask mask;
    private float moveVelocity;
    Rigidbody2D rb;
    private bool _canJump;
    private float degreeVelocity;
    private bool _canMove;
    private Vector3 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        _canJump = true;
        _canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;

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

        moveVelocity = 0;

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
        if(_canMove){
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        } else {
            Invoke("setCanMove", 0.5f);
        }
        if(rb.transform.position.y < -30){
            Destroy(player);
            SceneManager.LoadScene("DeathMenu");  
        }
    }

    void setCanJump() {
        this._canJump = true;
    }

    void setCanMove() {
        this._canMove = true;
    }

    private bool IsGrounded() {
       var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, mask);
       return groundCheck.collider != null && groundCheck.collider.CompareTag("Ground");
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Wall") {
            this._canMove = false;
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);
            print(rb.velocity);
            rb.velocity = direction*Mathf.Max(speed*2, 0f);
            print(rb.velocity);
        }
    }
}
