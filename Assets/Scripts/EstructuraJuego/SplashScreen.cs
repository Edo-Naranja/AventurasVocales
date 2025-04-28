using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{    
    void Start()
    {
        Invoke(nameof(CargarStart),3f);
    }
    void CargarStart()
    {
        SceneManager.LoadScene(1);  
    }
}
