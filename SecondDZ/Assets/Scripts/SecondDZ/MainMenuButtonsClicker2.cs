using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuButtonsClicker2 : MonoBehaviour
{
    [SerializeField] private RectTransform mainMenuButtons;
    [SerializeField] private TextMeshProUGUI mainMenuText;
    [SerializeField] private TextMeshProUGUI buttonSelectionText;
    [SerializeField] private Button buttonBack;
    [SerializeField] private Button menuButtons;
    [SerializeField] private Button menuToggles;
    [SerializeField] private Button menuDrops;
    [SerializeField] private Button menuInput;
    [SerializeField] private Button menuScrollView;
    [SerializeField] private MenuButtonsClicker menuButtonsClicker;
    [SerializeField] private MenuTogglesClicker menuTogglesClicker;
    [SerializeField] private MenuDropsClicker menuDropsClicker;
    [SerializeField] private MenuInputClicker menuInputClicker;
    [SerializeField] private MenuInputClicker MenuScrollView;
    private string mainMenuButtonsName="Main Menu";
    public string MainMenuButtonsName { get => mainMenuButtonsName; }
    public Button ButtonBack { get => buttonBack; }
    public RectTransform MainMenuButtons { get => mainMenuButtons; }
    public TextMeshProUGUI MainMenuText { get => mainMenuText; }
    public TextMeshProUGUI ButtonSelectionText { get => buttonSelectionText; }
    void Start()
    {
        menuButtons.onClick.AddListener(delegate { ChangeMenu(menuButtonsClicker.MenuButtons, menuButtonsClicker.CurrentButtonText, menuButtonsClicker.MenuButtonsName); });
        menuToggles.onClick.AddListener(delegate { ChangeMenu(menuTogglesClicker.MenuToggles, menuTogglesClicker.CurrentToggleText, menuTogglesClicker.MenuTogglesName); });
        menuDrops.onClick.AddListener(delegate { ChangeMenu(menuDropsClicker.MenuDrops, menuDropsClicker.CurrentDropsText, menuDropsClicker.MenuDropsName); });
        menuInput.onClick.AddListener(delegate { ChangeMenu(menuInputClicker.MenuInput, "", menuInputClicker.MenuInputName); });
        menuScrollView.onClick.AddListener(delegate { ChangeMenu(MenuScrollView.MenuInput, "", MenuScrollView.MenuScrollViewName); });
        mainMenuText.text= mainMenuButtonsName;
    }
    private void ChangeMenu(RectTransform menuRect, string selectionText,string MenuValueName)
    {
        mainMenuText.text = MenuValueName;
        mainMenuButtons.gameObject.SetActive(false);
        menuRect.gameObject.SetActive(true);
        buttonBack.gameObject.SetActive(true);
        buttonSelectionText.gameObject.SetActive(true);
        buttonSelectionText.text = selectionText;
    }
}
