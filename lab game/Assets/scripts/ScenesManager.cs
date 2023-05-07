using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    void Awake(){
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start(){}
    // Update is called once per frame
    void Update(){}
    public enum Scene{
        startMenu,
        level1_Directions,
        level1,
        level2_Directions,
        level2,
        level3_Directions,
        level3,
        highscores
        // level1_Directions,
        // level2_Directions,
        // level3_Directions
    }
    public void LoadScene(Scene scene){
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame(){
        SceneManager.LoadScene(Scene.level1_Directions.ToString());
    }
    public void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void LoadPreviousScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void LoadMainMenu(){
        SceneManager.LoadScene(Scene.startMenu.ToString());
    }
    // public void ReloadLevel(){
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
}
