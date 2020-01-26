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

    public void ResetIndex()
    {
        currentDataIndex = 0;
        chosenDataIndex = 0;
    }

    public void ShowData()
    {
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

        yield return new WaitForSeconds(1.25f);

        currentDataIndex = chosenDataIndex;

        ShowData();
    }

    public void ShowNextData()
    {
        chosenDataIndex = currentDataIndex + 1;

        UIManager.instance.SetLeftButtonVisibility(true);

        if (chosenDataIndex == dataContainers.Length - 1) 
            UIManager.instance.SetRightButtonVisibility(false);

        UIManager.instance.SetCurrentInfo(dataContainers[chosenDataIndex]);

        StartCoroutine(HideCurrentAndShowChosenData());
    }

    public void ShowPreviousData()
    {
        chosenDataIndex = currentDataIndex - 1;

        UIManager.instance.SetRightButtonVisibility(true);

        if (chosenDataIndex == 0)
            UIManager.instance.SetLeftButtonVisibility(false);

        UIManager.instance.SetCurrentInfo(dataContainers[chosenDataIndex]);

        StartCoroutine(HideCurrentAndShowChosenData());
    }
}
