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
    private Animator anim;
    private string _currentScene;
    
    public AudioSource audioSource;
    public AudioClip clipDeath;
    public AudioClip clipBounce;
    public AudioClip clipJump;
    public AudioClip clipWin;
    public float volume=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        audioSource = GetComponent<AudioSource>();
        _canJump = true;
        _canMove = true;
        anim = gameObject.GetComponent<Animator>();
        _currentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
        anim.SetBool("runRight", false);
        anim.SetBool("runLeft", false);
    
        if(Input.GetAxis("Jump") > 0 && IsGrounded() && _canJump) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            audioSource.PlayOneShot(clipJump, volume);
            _canJump = false;
            Invoke("setCanJump", 0.5f);
        }

        if(!IsGrounded()){
            anim.SetBool("Jump", true);
            if(Input.GetAxis("Vertical") != 0){
                if(Input.GetAxis("Vertical") > 0){
                    degreeVelocity -= degree;
                } else {
                    degreeVelocity += degree;
                }
                transform.eulerAngles = Vector3.forward * degreeVelocity;
            }
        } else {
            anim.SetBool("Jump", false);
        }

        moveVelocity = 0;

        if(Input.GetAxis("Horizontal") != 0){
            if(Input.GetAxis("Horizontal") > 0){
                if(_canJump){
                    anim.SetBool("runRight", true);
                }
                if(moveVelocity >= maxSpeed){
                    moveVelocity = maxSpeed;
                } else {
                    moveVelocity += walkSpeed;
                }
            } else {
                if(_canJump){
                    anim.SetBool("runLeft", true);
                }
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
        if(rb.transform.position.y < -20){
            audioSource.PlayOneShot(clipDeath, volume);
            Invoke("changeScene", clipDeath.length + 0.3f);
        }
    }

    void changeScene() {
            Destroy(player);
            if(_currentScene == "Tutorial"){
                SceneManager.LoadScene("Tutorial");
            } else {
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
            audioSource.PlayOneShot(clipBounce, volume);
            //print(col.gameObject.bounds);
            this._canMove = false;
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);
            print(rb.velocity);
            rb.velocity = direction*Mathf.Max(speed*2, 0f);
            print(rb.velocity);
        } 

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Finish"){
            audioSource.PlayOneShot(clipWin, volume);
            Invoke("changeSceneEnd", clipWin.length + 0.3f);
        }
    } 
    void changeSceneEnd() {
        Destroy(player);
        if(_currentScene == "Tutorial"){
            SceneManager.LoadScene("Menu");
        } else {
            SceneManager.LoadScene("VictoryMenu");
        }
    }
}
