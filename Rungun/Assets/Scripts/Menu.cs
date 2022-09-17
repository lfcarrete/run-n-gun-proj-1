using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Scene1() {  
        SceneManager.LoadScene("Fase1");  
    }
    public void Scene2() {  
        SceneManager.LoadScene("Tutorial");  
    }  
}
