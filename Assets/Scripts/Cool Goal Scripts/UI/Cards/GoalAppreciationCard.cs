using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAppreciationCard : BaseUICard
{
    [SerializeField] private List<string> goalAppreciationTextsAvailableInGame;

    public override void DisplayCard(string mainText, string subText)
    {
        base.DisplayCard(mainText, subText);

        string textToDisplay = "Goal!";
        if (goalAppreciationTextsAvailableInGame.Count != 0)
            textToDisplay = goalAppreciationTextsAvailableInGame[Random.Range(0, goalAppreciationTextsAvailableInGame.Count - 1)];

        this.mainText.text = textToDisplay;
    }
}
