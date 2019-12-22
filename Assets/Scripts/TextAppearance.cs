using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextAppearance : Appearance
{
    public float scalingDuration;

    private void Start()
    {
        SetChildrenActive(false);
    }

    public override void Appear()
    {
        SetChildrenActive(true);

        transform.localScale = Vector3.zero;
        transform.DOScale(1f,scalingDuration);
    }

    public override void Disappear()
    {
        transform.DOScale(0f, scalingDuration);
    }
}
