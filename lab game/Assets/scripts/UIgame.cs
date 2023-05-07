using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIgame : MonoBehaviour
{
    [SerializeField] Button startLevelBtn;
    // Start is called before the first frame update
    void Start()
    {
        startLevelBtn.onClick.AddListener(startLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void startLevel(){
        ScenesManager.Instance.LoadNextScene(); //go to next scene
    }
}
