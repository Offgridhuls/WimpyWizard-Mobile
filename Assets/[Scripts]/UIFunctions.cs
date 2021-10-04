using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//Julian Sangiorgio
//101268880
//2021-10-03
//Goal of this program is to show the functionality of my UI options
public class UIFunctions : MonoBehaviour
{
    
    [Header("UI Functions")] 
    public GameObject pauseCanvas;

    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
