using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBackMain : MonoBehaviour
{
    [SerializeField] Button backToMain;
    // Start is called before the first frame update
    void Start()
    {
        backToMain.onClick.AddListener(goToMain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void goToMain(){
        ScenesManager.Instance.LoadMainMenu();
    }
}
