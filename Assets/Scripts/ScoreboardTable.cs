using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardTable : MonoBehaviour
{

    private Transform Container;
    private Transform LigneTemplate;
    void Awake()
    {
        Container = transform.Find("Container");
        LigneTemplate = transform.Find("LigneTemplate");

        LigneTemplate.gameObject.SetActive(false);

        float templateHeight = 20f;
        for (int i = 0 ; i < 10 ; i++)
        {
            Transform entryTransform = Instantiate(LigneTemplate,Container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, - templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
    
}
