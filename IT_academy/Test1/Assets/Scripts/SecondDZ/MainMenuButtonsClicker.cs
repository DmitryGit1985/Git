using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuButtonsClicker : MonoBehaviour
{
    [SerializeField]
    private Image buttonBack;
    [SerializeField]
    private TextMeshProUGUI textMainMenu;
    [SerializeField]
    private TextMeshProUGUI buttonSelectionText;
    [SerializeField]
    private Image imageButtons;
    [SerializeField]
    private Image imageToggles;
    [SerializeField]
    private Image imageDrops;
    [SerializeField]
    private Image imageInput;
    [SerializeField]
    private Image imageScrollView;
    private UiElmentsCanvasClicker uiElmentsCanvasClicker;
    [SerializeField]
    private GameObject uiElmentsCanvasClickerGo;
    private GameObject uiElement;
    private MenuVariants menuVariants;
    [SerializeField]
    private GameObject menuVariantsGo;
    private MenuButtonsClicker menuButtonsClicker;
    [SerializeField]
    private GameObject menuButtonsClickerGo;
    private MenuTogglesClicker menuTogglesClicker;
    [SerializeField]
    private GameObject menuTogglesClickerGo;
    private MenuDropsClicker menuDropsClicker;
    [SerializeField]
    private GameObject menuDropsClickerGo;
    void Awake()
    {
        menuVariants = menuVariantsGo.GetComponent<MenuVariants>();
        uiElmentsCanvasClicker= uiElmentsCanvasClickerGo.GetComponent<UiElmentsCanvasClicker>();
        menuButtonsClicker=menuButtonsClickerGo.GetComponent<MenuButtonsClicker>();
        menuTogglesClicker= menuTogglesClickerGo.GetComponent<MenuTogglesClicker>();
        menuDropsClicker = menuDropsClickerGo.GetComponent<MenuDropsClicker>();
    }
    void Update()
    {
        MainMenuClicked();
    }
    private void MainMenuClicked()
    {
        if (uiElmentsCanvasClicker.GetSetUiElementClicked != null&& uiElmentsCanvasClicker.GetSetUiElementClicked.name !=buttonBack.name)
        {
            uiElement = uiElmentsCanvasClicker.GetSetUiElementClicked;
            FindButtonClicked(imageButtons.name, 0, menuButtonsClicker.GetSetCurrentButtonText);
            FindButtonClicked(imageToggles.name, 1, menuTogglesClicker.GetSetCurrentToggleText);
            FindButtonClicked(imageDrops.name, 2, menuDropsClicker.GetSetCurrentDropsText);
            FindButtonClicked(imageInput.name, 3, "");
            FindButtonClicked(imageScrollView.name, 4, "");
        }
    }
    private void FindButtonClicked(string name,int buttonNumber,string selectionText)
    {
        if (uiElement.name == name)
        {
            menuVariants.GetSetMainMenu.gameObject.SetActive(false);
            menuVariants.GetSetMenuVariants[buttonNumber].gameObject.SetActive(true);
            textMainMenu.text=menuVariants.GetSetMenuVariantsNames[buttonNumber];
            buttonBack.gameObject.SetActive(true);
            buttonSelectionText.gameObject.SetActive(true);
            buttonSelectionText.text = selectionText;
        }
    }
    public Image GetSetImageButtons
    {
        get
        {
            return imageButtons;
        }
        set
        {
            imageButtons = value;
        }
    }
}
