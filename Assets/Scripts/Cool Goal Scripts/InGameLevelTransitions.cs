using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InGameLevelTransitions : MonoBehaviour
{
    [SerializeField] private List<SubLevelImageData> subLevelImageData;
    [SerializeField] private Image bgImage;

    public static InGameLevelTransitions Instance;
    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void SubLevelTransition(int finalSubLevelIndex)
    {
        if(finalSubLevelIndex > subLevelImageData.Count)
        {
            finalSubLevelIndex = subLevelImageData.Count - 1;
        }

        GameObject imageToScale = subLevelImageData.Find(t => t.subLevelIndex == finalSubLevelIndex).transitionImage;
        imageToScale.transform.localScale = Vector3.one * 23f;

        imageToScale.SetActive(true);

        Sequence transitionSequence = DOTween.Sequence();
        transitionSequence.Append(imageToScale.transform.DOScale(Vector3.one * 1.3f, 0.3f));
        transitionSequence.Append(bgImage.DOFade(1, 0.3f));
        transitionSequence.AppendInterval(1.5f);
        transitionSequence.Append(bgImage.DOFade(0, 0.3f));
        transitionSequence.Append(imageToScale.transform.DOScale(Vector3.one * 23f, 0.3f));

        transitionSequence.OnComplete(() => imageToScale.SetActive(false));
    }
}

[System.Serializable]
public struct SubLevelImageData
{
    public int subLevelIndex;
    public GameObject transitionImage;
}
