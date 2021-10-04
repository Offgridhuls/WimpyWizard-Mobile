using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu; // Assign in inspector
    private bool isShowing;

    public void ShowPauseUI()
    {
        isShowing = !isShowing;
        pauseMenu.SetActive(isShowing);
    }
}
