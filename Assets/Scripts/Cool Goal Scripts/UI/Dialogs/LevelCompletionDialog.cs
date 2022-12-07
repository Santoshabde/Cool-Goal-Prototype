using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletionDialog : BaseDialog
{
    [SerializeField] private Button nextLevelButton;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
    }

    public override void OnOpenDialog()
    {
        base.OnOpenDialog();
    }

    public override void OnCloseDialog()
    {
        base.OnCloseDialog();
    }

    private void OnNextLevelButtonClicked()
    {
        int nextLevel = LevelLoader.currentLevelIndex + 1;
        LevelLoader.Instance.LoadLevel(LevelLoader.Instance.GetLevelID(nextLevel));
    }
}
