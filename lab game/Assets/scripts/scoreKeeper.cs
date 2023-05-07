using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreKeeper : MonoBehaviour
{
    [SerializeField] int score=0;
    //[SerializeField] GameObject skController;
    public GameObject balloonPrefab;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI healthTxt;
    [SerializeField] int level;
    public int arrow_pt=1;
    public int hitRow=0, shotsFired=0; //balloons hit in a row without missing
    public int healthVal;
    private const int default_pt=1, strong_pt=3, master_pt=5;//scores, the strength of the arrow
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health=3;
        DisplayScore();
        DisplayHealth();
    }
    public void scoringProcess(){
        addHit();
        playerRowHits();
        UpdateScore();
    }
    public void addHit(){
        hitRow++;
        Debug.Log("HIT");
    }
    public void ShotsFired(){
        shotsFired++;
    }
    public void playerRowHits(){
        if(hitRow==shotsFired){
            if((hitRow>=0)&&(hitRow<5)) arrow_pt=default_pt;
            else if((hitRow>=5)&&(hitRow<10)) arrow_pt=strong_pt; 
            else if(hitRow>=10) arrow_pt=master_pt;
        }
        else{
            hitRow=0;
            shotsFired=0;
        }
    }
    // Update is called once per frame
    void Update(){
        DisplayHealth();
        if(health==0){
            Debug.Log("GAME OVER");//restart scene
            health=3;
        }
    }
    public void decreaseHealth(){
        health--;
        // Debug.Log("Health: "+health);
    }
    public void UpdateScore()
    {
        score += arrow_pt;
        Debug.Log("Score: " + score);
        //display score
        DisplayScore();
        //PersistentData.Instance.SetScore(score);
    }
    public void addBigBalloon(){
        score+=50; //hit big balloon and get 50 points added
        DisplayScore();

    }
    public void DisplayScore()
    {
        scoreTxt.SetText("Score: " + score);
    }
    public void DisplayHealth(){
        //healthVal= skController.GetComponent<playerHealth>().getHealth();
        if(health>1) healthTxt.SetText(health+" lives left");
        else if(health==1) healthTxt.SetText(health+" life left");
        else if(health==0) healthTxt.SetText("Game Over");
    }
    public int getHealth(){
        return health;
    }
}
