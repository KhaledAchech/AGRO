using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewPlayer : MonoBehaviour
{
    public GameObject player_name;

    public LoadingScreenBarSystem loadingSystem;

    public void PlayGame()
  {
     newPlayer();
     //SceneManager.LoadScene("AncientForestLevel"); 
     loadingSystem.loadingScreen(2);
  }

  public void newPlayer()
  {
     if (player_name == null)
            player_name = GameObject.FindGameObjectWithTag("name");
     string name = player_name.GetComponent<Text>().text;
     int level = 1;
     int score = 0;

     Player nPlayer  = new Player (name, level, score);
     SaveSystem.SavePlayer(nPlayer);
  }

   public void Cancel()
  {
     SceneManager.LoadScene("Menu 3D"); 
  }
}
