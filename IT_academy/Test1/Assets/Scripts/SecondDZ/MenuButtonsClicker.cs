using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuButtonsClicker : MonoBehaviour
{
    [SerializeField]
    private Image buttonBack;
    [SerializeField]
    private TextMeshProUGUI textMainMenu;
    [SerializeField]
    private TextMeshProUGUI buttonSelectionText;
    [SerializeField]
    private Image buttonImageOne;
    [SerializeField]
    private Image buttonImageTwo;
    [SerializeField]
    private Image buttonImageDisable;
    private UiElmentsCanvasClicker uiElmentsCanvasClicker;
    [SerializeField]
    private GameObject uiElmentsCanvasClickerGo;
    private GameObject uiElement;
    private MenuVariants menuVariants;
    [SerializeField]
    private GameObject menuVariantsGo;
    private bool disableButtons;
    private string currentButtonText;
    private MainMenuButtonsClicker mainMenuButtonsClicker;
    [SerializeField]
    private GameObject mainMenuButtonsClickerGo;

    private void Awake()
    {
        menuVariants = menuVariantsGo.GetComponent<MenuVariants>();
        uiElmentsCanvasClicker = uiElmentsCanvasClickerGo.GetComponent<UiElmentsCanvasClicker>();
        mainMenuButtonsClicker= mainMenuButtonsClickerGo.GetComponent<MainMenuButtonsClicker>();
    }
    void Start()
    {
        currentButtonText = "One Clicked";
        buttonSelectionText.text = currentButtonText;
        disableButtons = false;
    }
    void Update()
    {
        MenuButtonsClicked();
    }
    public string GetSetCurrentButtonText
    {
        get
        {
            return currentButtonText;
        }
        set
        {
            currentButtonText = value;
        }
    }
    private void MenuButtonsClicked()
    {
        if (uiElmentsCanvasClicker.GetSetUiElementClicked != null)
        {
            uiElement = uiElmentsCanvasClicker.GetSetUiElementClicked;
            Debug.Log(uiElement);
        }
        
        if (disableButtons == false)
        {
            ButtonOneClicked();
            ButtonTwoClicked();
            ButtonDisableClicked();
        }
        ButtonBackClicked();
    }
    private void ButtonOneClicked()
    {
        if (uiElement.name == buttonImageOne.name)
        {
            currentButtonText = "One Clicked";
            buttonSelectionText.text = currentButtonText;
        }
    }
    private void ButtonTwoClicked()
    {
        if (uiElement.name == buttonImageTwo.name)
        {
            currentButtonText = "Two Clicked";
            buttonSelectionText.text = currentButtonText;
        }
    }
    private void ButtonDisableClicked()
    {
        if (uiElement.name == buttonImageDisable.name)
        {
            disableButtons = true;
            buttonImageOne.SetTransparency(100);
            buttonImageTwo.SetTransparency(100);
            buttonImageDisable.SetTransparency(100);
        }
    }
    private void ButtonBackClicked()
    {
        if (uiElement.name == buttonBack.name)
        {
            gameObject.SetActive(false);
            buttonBack.gameObject.SetActive(false);
            textMainMenu.text = menuVariants.GetSetMainMenuName;
            menuVariants.GetSetMainMenu.gameObject.SetActive(true);
            disableButtons = false;
            buttonImageOne.SetTransparency(255);
            buttonImageTwo.SetTransparency(255);
            buttonImageDisable.SetTransparency(255);
            buttonSelectionText.gameObject.SetActive(false);
        }  
    }
}