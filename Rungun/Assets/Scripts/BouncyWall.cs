using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWall : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {}

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player") {
            print("OI");
            anim.SetBool("bounce", true);
            Invoke("resetAnim",0.3f);
        }
    }
    void resetAnim(){
        anim.SetBool("bounce", false);
    }
}
