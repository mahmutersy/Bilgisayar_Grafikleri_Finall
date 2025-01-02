using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TekrarOyna : MonoBehaviour
{
    public void Tekrar()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  

        
        Time.timeScale = 1;
    }

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }
}
