using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    #region SINGLETON
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("Content")]
    public ScrollRect scrollRect;
    public TextMeshProUGUI buildingNameText;
    public TextMeshProUGUI buildingDescriptionText;

    [Header("Action Bar")]
    public Button leftButton;
    public Button rightButton;
    private Animator animator;

    [Header("Instruction elements")]
    public TextMeshProUGUI instructionText;
    public Image skylineIcon;

    private CityManager currentCityManager;

    private bool isInfoActive = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HideInstructions()
    {
        instructionText.DOFade(0f, 1f);
        skylineIcon.DOFade(0f, 1f);
    }

    public void ToggleInfo()
    {
        isInfoActive = !isInfoActive;
        animator.SetBool("InfoActive", isInfoActive);
    }

    public void SetCurrentCityManager(CityManager cityManager)
    {
        if (cityManager != currentCityManager)
        {
            currentCityManager = cityManager;
            SetCurrentInfo(currentCityManager.dataContainers[0]);
            SetLeftButtonVisibility(false);
        }
    }

    public void ShowPreviousBuilding()
    {
        currentCityManager.ShowPreviousData();
    }

    public void ShowNextBuilding()
    {
        currentCityManager.ShowNextData();
    }

    public void SetCurrentInfo(CityData currentData)
    {
        buildingNameText.text = currentData.nameIdentifier;
        buildingDescriptionText.text = currentData.description;
        scrollRect.normalizedPosition = new Vector2(0, 1);
    }

    public void SetActionBarVisibility(bool newVisibility)
    {
        animator.SetBool("ActionBarActive", newVisibility);
    }

    public void SetLeftButtonVisibility(bool newVisibility)
    {
        leftButton.gameObject.SetActive(newVisibility);
    }

    public void SetRightButtonVisibility(bool newVisibility)
    {
        rightButton.gameObject.SetActive(newVisibility);
    }
}
