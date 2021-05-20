using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PortalBehavior : MonoBehaviour
{
    public Player playerInfo;
    public GameObject name_text;

    public LoadingScreenBarSystem loadingSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void  OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hello: " + gameObject.name);
            Player player = new Player (name_text.GetComponent<Text>().text, playerInfo.level +1 ,ScoringSystem.Score);
            SaveSystem.SavePlayer(player);
            //Cursor.visible = true;
            //loadingSystem.loadingScreen(4);
            StartCoroutine(prepareScene());
        }
    }

    IEnumerator prepareScene()
    {
        yield return new WaitForSeconds(2);
        Cursor.visible = true;
        loadingSystem.loadingScreen(4);
    }
}
