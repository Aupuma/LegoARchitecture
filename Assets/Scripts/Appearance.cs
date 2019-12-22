using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Appearance : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void Appear();

    public abstract void Disappear();

    public void SetChildrenActive(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(state);
        }
    }
}
