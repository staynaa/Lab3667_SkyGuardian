using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    [SerializeField] Button startGame;
    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(startNew);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void startNew(){
        ScenesManager.Instance.LoadNewGame();
    }
}
