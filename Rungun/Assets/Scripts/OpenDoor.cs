using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator anim;
    public Object wall;
    public AudioSource audioSource;
    public AudioClip clip;

    public float volume=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(clip, volume);
            anim.SetBool("Open", true);
        }
    }
}
