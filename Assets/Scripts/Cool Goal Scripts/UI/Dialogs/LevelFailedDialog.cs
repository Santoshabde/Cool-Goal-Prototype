using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFailedDialog : BaseDialog
{
    [SerializeField] private Button retryButton;

    private void Awake()
    {
        retryButton.onClick.AddListener(OnRetryButtonClicked);
    }

    public override void OnCloseDialog()
    {
        base.OnCloseDialog();
    }

    public override void OnOpenDialog()
    {
        base.OnOpenDialog();
    }

    private void OnRetryButtonClicked()
    {
        int currentLevel = LevelLoader.currentLevelIndex;
        LevelLoader.Instance.LoadLevel(LevelLoader.Instance.GetLevelID(currentLevel));
    }
}
