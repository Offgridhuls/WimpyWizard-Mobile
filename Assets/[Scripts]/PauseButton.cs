using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Julian Sangiorgio
//101268880
//2021-10-03
//Goal of this program is to show the functionality of my UI options
public class PauseButton : MonoBehaviour
{
    [Header("Pause screen object")]
    public GameObject pauseMenu; 
    private bool isShowing;

    public void ShowPauseUI()
    {
        isShowing = !isShowing;
        pauseMenu.SetActive(isShowing);
    }
}
