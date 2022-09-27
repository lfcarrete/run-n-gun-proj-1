using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyLeft : MonoBehaviour
{
    public GameObject otherObject;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = otherObject.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update() {}

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            print("HIT LEFT");
            anim.SetBool("bounceLeft", true);
            print(anim.GetBool("bounceLeft"));
            Invoke("resetAnim",0.3f);
        }
    }
    void resetAnim(){
        anim.SetBool("bounceLeft", false);
        print(anim.GetBool("bounceLeft"));
    }
}
