using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTrackableEventHandler : DefaultTrackableEventHandler
{

    public Transform greyboxesParent;
    public Material occluderMaterial;
    public GameObject bWorldInfo;

    protected override void Start()
    {
        base.Start();

        foreach (var gb in greyboxesParent.GetComponentsInChildren<MeshRenderer>())
        {
            gb.material = occluderMaterial;
        }
    }

    protected override void OnTrackingFound()
    {
        
        base.OnTrackingFound();
        GetComponentInChildren<ImageAppearance>(true).enabled = true;

        foreach (var item in bWorldInfo.GetComponentsInChildren<Appearance>())
        {
            item.Appear();
        }
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
