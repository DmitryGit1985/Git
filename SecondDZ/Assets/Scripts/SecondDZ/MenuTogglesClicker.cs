using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuTogglesClicker : MonoBehaviour
{
    [SerializeField] private RectTransform menuToggles;
    [SerializeField] private Toggle toggle1;
    [SerializeField] private Toggle toggle2;
    [SerializeField] private Toggle toggle3;
    [SerializeField] private MainMenuButtonsClicker2 mainMenuButtonsClicker;
    private Toggle[] toggles;
    private string toggleText1;
    private string toggleText2;
    private string toggleText3;
    private string currentToggleText;
    private string menuTogglesName = "Toggles";
    public string MenuTogglesName { get => menuTogglesName; }
    public string CurrentToggleText { get => currentToggleText; }
    public RectTransform MenuToggles { get => menuToggles; }
    void Start()
    {
        mainMenuButtonsClicker.ButtonBack.onClick.AddListener(delegate { ButtonBackClicked(); });
        toggle1.isOn = true;
        toggle2.isOn = false;
        toggle3.isOn = false;
        toggleText1 = toggle1.GetComponentInChildren<TextMeshProUGUI>().text;
        toggleText2 = toggle2.GetComponentInChildren<TextMeshProUGUI>().text;
        toggleText3 = toggle3.GetComponentInChildren<TextMeshProUGUI>().text;
        toggle1.onValueChanged.AddListener(delegate { ToggleClicked(toggle1, toggleText1); });
        toggle2.onValueChanged.AddListener(delegate { ToggleClicked(toggle2, toggleText2); });
        toggle3.onValueChanged.AddListener(delegate { ToggleClicked(toggle3, toggleText3); });
        currentToggleText = toggleText1;
        mainMenuButtonsClicker.ButtonSelectionText.text = currentToggleText;

        toggles= GetComponentsInChildren<Toggle>();
    }
    private void ToggleClicked(Toggle currentToggle, string toggleText)
    {
        for (int i = 0; i < toggles.Length; i++) 
        {
            if (currentToggle != toggles[i] && currentToggle.isOn==true)
            {
                toggles[i].isOn = false;
            }
        }
        currentToggleText = toggleText;
        mainMenuButtonsClicker.ButtonSelectionText.text = currentToggleText;
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
