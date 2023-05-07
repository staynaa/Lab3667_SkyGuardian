using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] string playerName; 
    // difficulty; //player's name and the difficulty of game

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerName = "";
        
    }
    // Update is called once per frame
    void Update(){}

    public void SetName(string s)
    {
        playerName = s;
        Debug.Log("name: "+playerName);
    }

    public void SetScore(int s)
    {
        playerScore = s;
    }
    // public void setDifficulty(string diff){
    //     difficulty=diff;
    // }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }
    // public string getDifficulty(){
    //     return difficulty;
    // }
}
