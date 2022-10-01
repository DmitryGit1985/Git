using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonsClicker : MonoBehaviour
{
    [SerializeField] private RectTransform menuButtons;
    [SerializeField] private Image buttonOneImage;
    [SerializeField] private Image buttonTwoImage;
    [SerializeField] private Image buttonDisableImage;
    [SerializeField] private MainMenuButtonsClicker2 mainMenuButtonsClicker;
    private Button buttonOne;
    private Button buttonTwo;
    private Button buttonDisable;
    private bool disableButtons;
    private string currentButtonText;
    private string menuButtonsName="Buttons";
    public RectTransform MenuButtons { get => menuButtons; }
    public string CurrentButtonText { get => currentButtonText; }
    public string MenuButtonsName { get => menuButtonsName; }
    void Start()
    {
        buttonOne = buttonOneImage.GetComponent<Button>();
        buttonTwo = buttonTwoImage.GetComponent<Button>();
        buttonDisable = buttonDisableImage.GetComponent<Button>();
        mainMenuButtonsClicker.ButtonBack.onClick.AddListener(delegate { ButtonBackClicked(); });
        currentButtonText = "One Clicked";
        mainMenuButtonsClicker.ButtonSelectionText.text = currentButtonText;
        buttonOne.onClick.AddListener(delegate { ButtonOneOrTwoClicked("One Clicked"); ; });
        buttonTwo.onClick.AddListener(delegate { ButtonOneOrTwoClicked("Two Clicked"); ; });
        buttonDisable.onClick.AddListener(delegate { ButtonDisableClicked(); });
        disableButtons = false;
    }
    private void ButtonOneOrTwoClicked(string currentButtonValueText)
    {
        if (disableButtons == false)
        {
            currentButtonText = currentButtonValueText;
            mainMenuButtonsClicker.ButtonSelectionText.text = currentButtonText;
        }
    }
    private void ButtonDisableClicked()
    {
            disableButtons = true;
            buttonOneImage.SetTransparency(100);
            buttonTwoImage.SetTransparency(100);
            buttonDisableImage.SetTransparency(100);
    }
    private void ButtonBackClicked()
    {
            gameObject.SetActive(false);
            mainMenuButtonsClicker.ButtonBack.gameObject.SetActive(false);
            mainMenuButtonsClicker.MainMenuText.text = mainMenuButtonsClicker.MainMenuButtonsName;
            mainMenuButtonsClicker.MainMenuButtons.gameObject.SetActive(true);
            mainMenuButtonsClicker.ButtonSelectionText.gameObject.SetActive(false);
            disableButtons = false;
            buttonOneImage.SetTransparency(255);
            buttonTwoImage.SetTransparency(255);
            buttonDisableImage.SetTransparency(255);    
    }
}