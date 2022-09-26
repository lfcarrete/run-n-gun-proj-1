using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformsController : MonoBehaviour
{
    Rigidbody2D rb;
    private GameObject player;
    public float timeDestruction;
    public GameObject platform;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite newSprite2;
    private bool _destroyed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        _destroyed = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(!this._destroyed){
            this._destroyed = true;
            Invoke("DestroyPlatform", timeDestruction);
            Invoke("ChangeSprite", timeDestruction/3);
            Invoke("ChangeSpriteAgain", timeDestruction*2/3);
        }
    } 

    void DestroyPlatform(){
        Destroy(platform);
    }

    void ChangeSprite(){
        spriteRenderer.sprite = newSprite;

    }

    void ChangeSpriteAgain(){
        spriteRenderer.sprite = newSprite2;

    }}
