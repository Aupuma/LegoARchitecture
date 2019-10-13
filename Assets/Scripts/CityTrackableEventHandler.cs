using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTrackableEventHandler : DefaultTrackableEventHandler
{
    private Animator animator;
    public Transform cityCanvas;

    public Transform greyboxesParent;
    public Material occluderMaterial;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();

        foreach (var gb in greyboxesParent.GetComponentsInChildren<MeshRenderer>())
        {
            gb.material = occluderMaterial;
        }
    }

    protected override void OnTrackingFound()
    {
        
        base.OnTrackingFound();
        //cityCanvas.transform.DOMoveZ(transform.localPosition.z, 1f).ChangeStartValue(transform.localPosition.z - 0.232f);
        animator.SetTrigger("Appear");
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
