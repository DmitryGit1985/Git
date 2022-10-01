using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class MainMenuButtonsClicker : MonoBehaviour
{
    [SerializeField] private Image buttonBack;
    [SerializeField] private TextMeshProUGUI textMainMenu;
    [SerializeField] private TextMeshProUGUI buttonSelectionText;
    [SerializeField] private Image imageButtons;
    [SerializeField] private Image imageToggles;
    [SerializeField] private Image imageDrops;
    [SerializeField] private Image imageInput;
    [SerializeField] private Image imageScrollView;
    [SerializeField] private UiElmentsCanvasClicker uiElmentsCanvasClicker;
    [SerializeField] private MenuVariants menuVariants;
    [SerializeField] private MenuButtonsClicker menuButtonsClicker;
    [SerializeField] private MenuTogglesClicker menuTogglesClicker;
    [SerializeField] private MenuDropsClicker menuDropsClicker;
    private GameObject uiElement;
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            MainMenuClicked();
        }
    }
    private void MainMenuClicked()
    {
        if (uiElmentsCanvasClicker.UiElementClicked != null)
        {
            uiElement = uiElmentsCanvasClicker.UiElementClicked;
            FindButtonClicked(imageButtons.name, 0, menuButtonsClicker.CurrentButtonText);
            FindButtonClicked(imageToggles.name, 1, menuTogglesClicker.CurrentToggleText);
            FindButtonClicked(imageDrops.name, 2, menuDropsClicker.CurrentDropsText);
            FindButtonClicked(imageInput.name, 3, "");
            FindButtonClicked(imageScrollView.name, 4, "");
        }
    }
    private void FindButtonClicked(string name,int buttonNumber,string selectionText)
    {
        if (uiElement.name == name)
        {
            menuVariants.MainMenu.gameObject.SetActive(false);
            menuVariants.MenuVariants_[buttonNumber].gameObject.SetActive(true);
            textMainMenu.text=menuVariants.MenuVariantsNames[buttonNumber];
            buttonBack.gameObject.SetActive(true);
            buttonSelectionText.gameObject.SetActive(true);
            buttonSelectionText.text = selectionText;
        }
    }
    private void FindButtonClicked2(string name, string buttonName, string selectionText)
    {
        if (uiElement.name == name)
        {
            menuVariants.MainMenuButton.ButtonRect.gameObject.SetActive(false);

            //textMainMenu.text = menuVariants.MenuVariantsNames[buttonNumber];
            buttonBack.gameObject.SetActive(true);
            buttonSelectionText.gameObject.SetActive(true);
            buttonSelectionText.text = selectionText;
        }
    }
}
