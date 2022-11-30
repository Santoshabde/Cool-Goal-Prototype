using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseUICard : MonoBehaviour
{
    [SerializeField] protected Text mainText;
    [SerializeField] protected Text subText;

    public virtual void DisplayCard(string mainText, string subText)
    {
        //Generic card animations
        this.gameObject.SetActive(true);
    }

    public virtual void CloseCard()
    {
        this.gameObject.SetActive(false);
    }
}
