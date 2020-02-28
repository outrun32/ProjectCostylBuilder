using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("TestScene");    
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
}
