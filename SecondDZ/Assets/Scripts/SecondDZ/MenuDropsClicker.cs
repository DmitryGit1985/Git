using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuDropsClicker : MonoBehaviour
{
    [SerializeField] private RectTransform menuDrops;
    [SerializeField] private Image buttonBack;
    [SerializeField] private MainMenuButtonsClicker2 mainMenuButtonsClicker;
    private TMP_Dropdown dropdawn;
    private string currentDropsText;
    private string menuDropsName = "Drops";
    public string MenuDropsName { get => menuDropsName; }
    public string CurrentDropsText { get => currentDropsText; }
    public RectTransform MenuDrops { get => menuDrops; }

    void Start()
    {
        mainMenuButtonsClicker.ButtonBack.onClick.AddListener(delegate { ButtonBackClicked(); });
        dropdawn = GetComponentInChildren<TMP_Dropdown>();
        dropdawn.onValueChanged.AddListener(delegate { MenuDropsClicked(); });
        currentDropsText = dropdawn.options[dropdawn.value].text;
        mainMenuButtonsClicker.ButtonSelectionText.text = currentDropsText;
    }
    private void MenuDropsClicked()
    {
        currentDropsText = dropdawn.options[dropdawn.value].text;
        mainMenuButtonsClicker.ButtonSelectionText.text = currentDropsText;
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
