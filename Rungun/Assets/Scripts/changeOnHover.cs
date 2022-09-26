using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeOnHover : MonoBehaviour
{
    public Button button;
    public Text texto;
    public Color wantedColor;
    public Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeWhenHover(){
        button.image.color = new Color(wantedColor.r, wantedColor.g, wantedColor.b);
        texto.color = new Color(originalColor.r, originalColor.g, originalColor.b);

    }
    public void changeWhenLeave(){
        button.image.color = new Color(originalColor.r, originalColor.g, originalColor.b);
        texto.color = new Color(wantedColor.r, wantedColor.g, wantedColor.b);

    }
}
