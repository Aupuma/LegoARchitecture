using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CityDataAppearance : Appearance
{
    public Transform nameAndCountry;
    public Transform data;

    float verticalMovementDuration = 0.5f;
    float verticalMovementDistance = 170f;
    float horizontalMovementDuration = 0.5f;
    float horizontalMovementDistance = 60f;

    private void Start()
    {
        nameAndCountry.localPosition = new Vector3(0f, 0f, -horizontalMovementDistance);
    }

    public override void Appear()
    {
        nameAndCountry.DOLocalMoveZ(0f, horizontalMovementDuration);
        data.DOLocalMoveY(0f, verticalMovementDuration).ChangeStartValue(-verticalMovementDistance).SetDelay(0.5f);
    }

    public override void Disappear()
    {
        data.DOLocalMoveY(-verticalMovementDistance, verticalMovementDuration);
    }
}
