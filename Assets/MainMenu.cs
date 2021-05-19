using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
  public Animator transition;
  public float transitionTime = 1f;

  public LoadingScreenBarSystem loadingSystem;


  public void PlayGame()
  {
    //StartCoroutine(PlayTransition());
    loadData();
  }

  public void loadData()
  {
    PlayerData data = SaveSystem.LoadPlayer();
    if (data != null)
    {
      loadingSystem.loadingScreen(2);
      //SceneManager.LoadScene("AncientForestLevel"); 
    }
    else
    {
      loadingSystem.loadingScreen(3);
      //SceneManager.LoadScene("Prototype");
    }
  }

   public void NewGame()
  {
    SceneManager.LoadScene("NewGame"); 
  }

  public void QuitGame()
  {
    Application.Quit();
  }
/*
  IEnumerator PlayTransition()
  {
    transition.SetTrigger("Start");

    yield return new WaitForSeconds(transitionTime);

  }
*/
}
