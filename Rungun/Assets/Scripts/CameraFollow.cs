using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Slider volumeSlider;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update () {
        if(player != null){
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
        if(audioSource != null){
            audioSource.volume = volumeSlider.value;
        }
    }
}