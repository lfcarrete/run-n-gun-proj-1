using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyRight : MonoBehaviour
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
            print("BounceRight");
            anim.SetBool("bounceRight", true);
            Invoke("resetAnim",0.3f);
        }
    }
    void resetAnim(){
        anim.SetBool("bounceRight", false);
    }
}
