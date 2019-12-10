using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    public CityData[] dataContainers;
    public GameObject[] buildingWorldDataObjs;
    private int currentDataIndex = 0;
    private int chosenDataIndex = 0;
    Appearance[] currentWorldDataAnimations;

    // Start is called before the first frame update
    void Start()
    {
        if (dataContainers.Length != buildingWorldDataObjs.Length)
        {
            Debug.LogError("TAMAÑO DE ARRAYS DE DATOS DE EDIFICIOS NO COINCIDE");
        }
    }

    public void ShowData()
    {
        buildingWorldDataObjs[currentDataIndex].SetActive(true);

        currentWorldDataAnimations = buildingWorldDataObjs[currentDataIndex].GetComponentsInChildren<Appearance>();
        foreach (var item in currentWorldDataAnimations)
        {
            item.Appear();
        }
    }

    IEnumerator HideCurrentAndShowChosenData()
    {
        foreach (var item in currentWorldDataAnimations)
        {
            item.Disappear();
        }

        yield return new WaitForSeconds(1f);

        buildingWorldDataObjs[currentDataIndex].SetActive(true);
        currentDataIndex = chosenDataIndex;

        ShowData();
    }

    public void ShowNextData()
    {
        chosenDataIndex = currentDataIndex + 1;
        StartCoroutine(HideCurrentAndShowChosenData());
    }

    public void ShowPreviousData()
    {
        chosenDataIndex = currentDataIndex - 1;
        StartCoroutine(HideCurrentAndShowChosenData());
    }
}
