using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWall : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D body;
    private Vector3 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        body = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = body.velocity;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player") {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);
            print(body.velocity);
            body.AddForce(direction*Mathf.Max(speed, 0f), ForceMode2D.Impulse);
            //body.velocity = direction*Mathf.Max(speed, 0f);
            print(body.velocity);
        }
    }
}
