using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float walkSpeed;
    public float jumpHeight;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Jump") > 0 && IsGrounded()) {
            print("pulei");
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded() {
        
       var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.7f);
       print(groundCheck.collider.tag);
       return groundCheck.collider != null && groundCheck.collider.CompareTag("Ground");
    }
}
