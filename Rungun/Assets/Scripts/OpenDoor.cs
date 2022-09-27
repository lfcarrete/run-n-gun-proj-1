using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator anim;
    public Object wall;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("End")){
            Destroy(wall);
        }
    }
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player") {
            anim.SetBool("Open", true);
        }
    }
}
