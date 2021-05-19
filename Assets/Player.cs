using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name ;
    public int level;
    public int score; 

    public Player(string name, int level, int score)
    {
        this.name = name;
        this.level = level;
        this.score = score;
    }
    // Start is called before the first frame update
    void Start()
    {
        loadData();
    }

    public void loadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        name = data.name;
        level = data.level;
        score = data.score;

        //update ui
        ScoringSystem.Score = score;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
