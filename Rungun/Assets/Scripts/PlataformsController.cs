using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformsController : MonoBehaviour
{
    Rigidbody2D rb;
    private GameObject player;
    public float timeDestruction;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        Invoke("DestroyPlatform", timeDestruction);
    } 

    void DestroyPlatform(){
        Destroy(platform);
    }
}
