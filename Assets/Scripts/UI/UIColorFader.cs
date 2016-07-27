using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class UIColorFader : MonoBehaviour
{
    [SerializeField]
    private float fadeDuration = 2f;
    [SerializeField]
    private float delay = 4f;

    private Graphic graphic;
    private Color initialColor;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (graphic == null)
        {
            graphic = GetComponent<Graphic>();
            initialColor = graphic.color;
        }
    }

    public void Play()
    {
        Initialize();
        gameObject.SetActive(true);
        graphic.color = initialColor;
        graphic.DOFade(0, fadeDuration).SetDelay(delay).OnComplete(FadeCompleted);
    }

    private void FadeCompleted()
    {
        gameObject.SetActive(false);
    }
}
