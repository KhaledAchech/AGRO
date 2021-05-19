using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public int level;
    public int score ;


    public PlayerData(Player player) 
    {
        name = player.name;
        level = player.level;
        score = player.score;
    }
    
}
