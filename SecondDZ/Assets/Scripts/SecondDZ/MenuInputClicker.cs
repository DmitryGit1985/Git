using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputClicker : MonoBehaviour
{
    [SerializeField] private RectTransform menuInput;
    [SerializeField] private MainMenuButtonsClicker2 mainMenuButtonsClicker;
    private string menuInputName = "Input";
    private string menuScrollViewName = "Scroll View";
    public string MenuInputName { get => menuInputName; }
    public string MenuScrollViewName { get => menuScrollViewName; }
    public RectTransform MenuInput { get => menuInput; }
    void Start()
    {
        mainMenuButtonsClicker.ButtonBack.onClick.AddListener(delegate { ButtonBackClicked(); });
    }
    private void ButtonBackClicked()
    {
        gameObject.SetActive(false);
        mainMenuButtonsClicker.ButtonBack.gameObject.SetActive(false);
        mainMenuButtonsClicker.MainMenuText.text = mainMenuButtonsClicker.MainMenuButtonsName;
        mainMenuButtonsClicker.MainMenuButtons.gameObject.SetActive(true);
        mainMenuButtonsClicker.ButtonSelectionText.gameObject.SetActive(false);
    }
}
