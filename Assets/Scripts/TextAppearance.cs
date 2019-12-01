using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextAppearance : Appearance
{
    public float scalingDuration;

    public override void Appear()
    {
        transform.DOScale(0f, scalingDuration).From();
    }

    public override void Disappear()
    {
        transform.DOScale(0f, scalingDuration);
    }
}
