using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CityData", menuName = "ScriptableObjects/CityDataContainer", order = 1)]
public class CityData : ScriptableObject
{
    public string nameIdentifier;

    [TextArea(15, 20)]
    public string description;
}
