using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreSceneManager : MonoBehaviour
{
    public GameObject score_Value;
    // Start is called before the first frame update
    void Start()
    {
        loadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        score_Value.GetComponent<Text>().text = data.score + "";
        
    }

    public void MainMenu()
  {
     SceneManager.LoadScene("Menu 3D"); 
  }

   public void ScoreBoard()
   {

   }

   public void LevelSelection()
   {
       
   }
}
