using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CityDataAppearance : Appearance
{
    public Transform nameAndCountry;
    public Transform data;

    float verticalMovementDuration = 0.5f;
    float verticalMovementDistance = 145f;
    float horizontalMovementDuration = 0.5f;
    float horizontalMovementDistance = 60f;

    public override void Appear()
    {
        nameAndCountry.DOLocalMoveZ(horizontalMovementDistance, horizontalMovementDuration).From();
        data.DOLocalMoveY(-verticalMovementDistance, verticalMovementDuration).From().SetDelay(0.5f);
    }

    public override void Disappear()
    {
        data.DOLocalMoveY(-verticalMovementDistance, verticalMovementDuration);
    }
}
