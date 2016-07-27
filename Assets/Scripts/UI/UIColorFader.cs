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
        graphic = GetComponent<Graphic>();
        initialColor = graphic.color;
    }

    public void Play()
    {
        gameObject.SetActive(true);
        graphic.color = initialColor;
        graphic.DOFade(0, fadeDuration).SetDelay(delay).OnComplete(FadeCompleted);
    }

    private void FadeCompleted()
    {
        gameObject.SetActive(false);
    }
}
