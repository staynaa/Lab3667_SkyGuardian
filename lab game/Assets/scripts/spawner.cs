using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public List<GameObject> objSpawned = new List<GameObject>();
    public bool isRand;

    public float timeToSpawn; //how often to spawn
    private float curTimeToSpawn; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(curTimeToSpawn>0){
            curTimeToSpawn-= Time.deltaTime;
        }else{
            spawnObj();
            curTimeToSpawn=timeToSpawn;
        }
    }

    public void spawnObj(){
        float xMin = -8f;
        float xMax = 10.0f;

        int i = isRand ? Random.Range(0,objSpawned.Count) : 0; //get random index to represent the element that'll spawn

        if(objSpawned.Count > 0){
            float x=Random.Range(xMin, xMax);
            // Debug.Log("X=" + x);
            Vector2 pos = new Vector2(x, transform.position.y);
            Instantiate(objSpawned[i],pos,objSpawned[i].transform.rotation);
        }
    }
}
