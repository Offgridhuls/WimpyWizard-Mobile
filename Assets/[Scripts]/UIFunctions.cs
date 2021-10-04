using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIFunctions : MonoBehaviour
{
    //public GameObject pauseCanvas;
    // Start is called before the first frame update
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

}
