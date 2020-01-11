using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ImageAppearance : Appearance
{
    public GameObject imgChild;
    public float verticalMovementDuration = 1.5f;
    public float verticalMovementDistance = 100f;
    public float scalingDuration = 1f;
    public float initialScale = 1f;

    Sequence mySequence;

    // Start is called before the first frame update
    void Start()
    {
        mySequence = DOTween.Sequence();
        mySequence.SetAutoKill(false);
        mySequence.Append(transform.DOLocalMoveY(transform.localPosition.y - verticalMovementDistance,
           verticalMovementDuration).From());
        mySequence.Append(imgChild.transform.DOScale(initialScale, scalingDuration).From());
        mySequence.Pause();

        SetChildrenActive(false);
    }

    public override void Appear()
    {
        SetChildrenActive(true);

        mySequence.Goto(0);
        mySequence.PlayForward();
    }

    public override void Disappear()
    {
        mySequence.PlayBackwards();
    }
}
