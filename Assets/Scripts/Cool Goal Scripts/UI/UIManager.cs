using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<BaseDialog> inGameUIDialogs;
    [SerializeField] private List<BaseUICard> inGameCards;

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void OpenDialog<T>() where T: BaseDialog
    {
        foreach (var dialog in inGameUIDialogs)
        {
            if(Types.Equals(typeof(T), dialog.GetType()))
            {
                dialog.OnOpenDialog();
                break;
            }
        }
    }

    public void CloseDialog<T>() where T : BaseDialog
    {
        foreach (var dialog in inGameUIDialogs)
        {
            if (Types.Equals(typeof(T), dialog.GetType()))
            {
                dialog.OnCloseDialog();
                break;
            }
        }
    }

    public void DisplayCard<T>(string mainText = null, string subText = null) where T: BaseUICard
    {
        foreach (var card in inGameCards)
        {
            if (Types.Equals(typeof(T), card.GetType()))
            {
                card.DisplayCard(mainText, subText);
                break;
            }
        }
    }

    public void CloseCard<T>() where T : BaseUICard
    {
        foreach (var card in inGameCards)
        {
            if (Types.Equals(typeof(T), card.GetType()))
            {
                card.CloseCard();
                break;
            }
        }
    }

    public void CloseAllDialogs()
    {
        inGameUIDialogs.ForEach(t => t.OnCloseDialog());
    }

    public void CloseAllCards()
    {
        inGameCards.ForEach(t => t.CloseCard());
    }
}
