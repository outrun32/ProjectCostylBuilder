using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButton : MonoBehaviour
{
    public Image Backgroundimage;
    public Color Normalcolor;
    public Color Highlightcolor;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void OnGazeEnter()
    {
        Backgroundimage.color = Highlightcolor;
    }
    public void OnGazeExit()
    {
        Backgroundimage.color = Normalcolor;
    }
}
