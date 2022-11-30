using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseDialog : MonoBehaviour
{
    public virtual void OnOpenDialog()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnCloseDialog()
    {
        gameObject.SetActive(false);
    }
}
