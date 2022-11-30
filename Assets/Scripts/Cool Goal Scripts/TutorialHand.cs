using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHand : MonoBehaviour
{
    private void Awake()
    {
        InputController.Instance.OnScreenTouchDown += OnTouch;
        //gameObject.SetActive(false);
    }

    private void OnTouch()
    {
        InputController.Instance.OnScreenTouchDown -= OnTouch;
        Destroy(this.gameObject);
    }
}
