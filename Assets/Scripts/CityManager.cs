using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    public CityData[] dataContainers;
    public GameObject[] buildingWorldDataObjs;
    private int currentDataIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (dataContainers.Length != buildingWorldDataObjs.Length)
        {
            Debug.LogError("TAMAÑO DE ARRAYS DE DATOS DE EDIFICIOS NO COINCIDE");
        }
    }

    public void ShowNextData()
    {
        currentDataIndex++;
    }

    public void ShowPreviousData()
    {

    }
}
