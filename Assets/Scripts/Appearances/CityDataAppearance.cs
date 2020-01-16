using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CityDataAppearance : Appearance
{
    public Transform nameAndCountry;
    public Transform data;

    public float verticalMovementDuration = 0.5f;
    public float verticalMovementDistance = 170f;
    public float horizontalMovementDuration = 0.5f;
    public float horizontalMovementDistance = 60f;

    private void Start()
    {
        nameAndCountry.localPosition = new Vector3(0f, 0f, horizontalMovementDistance);
        data.localPosition = new Vector3(0f, -verticalMovementDistance, 0f);
    }

    public override void Appear()
    {
        nameAndCountry.DOLocalMoveY(1f, 0.1f);
        nameAndCountry.DOLocalMoveZ(0f, horizontalMovementDuration);
        data.DOLocalMoveY(0f, verticalMovementDuration).SetDelay(0.5f);
    }

    public override void Disappear()
    {
        data.DOLocalMoveY(-verticalMovementDistance, verticalMovementDuration);
    }
}
