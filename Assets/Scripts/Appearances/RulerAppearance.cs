using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class RulerAppearance : Appearance
{
    // Start is called before the first frame update
    public RectTransform rulerTransform;
    public TextMeshProUGUI rulerText;

    public float verticalMovementDistance;
    public float verticalMovementDuration;

    public float rulerRealDistance;
    public float rulerEnlargeDuration;

    bool updateText = false;
    float distanceMultiplier;

    Sequence sequence;

    private void Start()
    {
        distanceMultiplier = rulerRealDistance / rulerTransform.sizeDelta.y;

        sequence = DOTween.Sequence();
        sequence.SetAutoKill(false);
        sequence.Append(transform.DOLocalMoveY(transform.localPosition.y - verticalMovementDistance,
           verticalMovementDuration).From());
        sequence.Append(rulerTransform.DOSizeDelta(new Vector2(100, 0), rulerEnlargeDuration).From());
        sequence.OnComplete(() =>
        {
            updateText = false;
        });
        sequence.Pause();

        SetChildrenActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (updateText)
        {
            float currentHeight = rulerTransform.sizeDelta.y * distanceMultiplier;
            rulerText.text = currentHeight.ToString("F1") + " m";
        } 
    }

    public override void Appear()
    {
        SetChildrenActive(true);
        updateText = true;
        sequence.Goto(0);
        sequence.PlayForward();
    }

    public override void Disappear()
    {
        updateText = true;
        sequence.PlayBackwards();
    }
}
