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

    public Transform cityInfoTransform;
    public TextMeshProUGUI buildingNameText;
    public TextMeshProUGUI buildingDescriptionText;
    public Button leftButton;
    public Button RightButton;
    private Animator animator;

    private CityManager currentCityManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowPreviousBuilding()
    {

    }

    public void ShowNextBuilding()
    {

    }

    public void SetScreenInfoVisibility(bool newVisibility)
    {
        animator.SetBool("InfoActive", newVisibility);
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
        leftButton.gameObject.SetActive(newVisibility);
    }

    public void SetCityManager(CityManager cityManager)
    {
        if(cityManager != currentCityManager)
        {

        }
        currentCityManager = cityManager;

    }
}
