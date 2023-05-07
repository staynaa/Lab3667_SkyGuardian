using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuObj;
    // public GameObject pauseBtn;
    public static bool isPaused;
    void Start()
    {
        pauseMenuObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pause(){
        pauseMenuObj.SetActive(true);
        Time.timeScale=0f;
        isPaused=true;
    }
    public void Resume(){
        pauseMenuObj.SetActive(false);
        Time.timeScale=1f;
        isPaused=false;
    }
    void goToMain(){
        Time.timeScale=1f;
        SceneManager.LoadScene("startMenu");
    }
}
