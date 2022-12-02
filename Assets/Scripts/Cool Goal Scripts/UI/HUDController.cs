using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private List<GameObject> subLevelIndicators; //0th child - incomplete, 1th child - in progress and 2nd child - completed

    public static HUDController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void UpdateLevelInfoHUD(string currentLevel, string nextLevel, int currentSubLevelIndex)
    {
        currentLevelText.text = currentLevel;
        nextLevelText.text = nextLevel;

        int currentIndex = 0;
        foreach (var indicator in subLevelIndicators)
        {
            if(currentIndex < currentSubLevelIndex)
            {
                indicator.transform.GetChild(2).gameObject.SetActive(true);
                indicator.transform.GetChild(1).gameObject.SetActive(false);
                indicator.transform.GetChild(0).gameObject.SetActive(false);
            }

            else if(currentIndex == currentSubLevelIndex)
            {
                indicator.transform.GetChild(1).gameObject.SetActive(true);
                indicator.transform.GetChild(2).gameObject.SetActive(false);
                indicator.transform.GetChild(0).gameObject.SetActive(false);
            }   
            
            else if(currentIndex > currentSubLevelIndex)
            {
                indicator.transform.GetChild(0).gameObject.SetActive(true);
                indicator.transform.GetChild(1).gameObject.SetActive(false);
                indicator.transform.GetChild(2).gameObject.SetActive(false);
            }

            currentIndex += 1;
        }
    }
}
