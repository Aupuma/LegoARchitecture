using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTrackableEventHandler : DefaultTrackableEventHandler
{

    public Transform greyboxesParent;
    public Material occluderMaterial;
    public GameObject bWorldInfo;

    CityManager myCityManager;

    protected override void Start()
    {
        base.Start();

        myCityManager = GetComponent<CityManager>();
        foreach (var gb in greyboxesParent.GetComponentsInChildren<MeshRenderer>())
        {
            gb.material = occluderMaterial;
        }
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        UIManager.instance.SetCityManager(myCityManager);
        UIManager.instance.SetActionBarVisibility(true);
        myCityManager.ShowData();
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        if(myCityManager!=null)
            UIManager.instance.SetActionBarVisibility(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
