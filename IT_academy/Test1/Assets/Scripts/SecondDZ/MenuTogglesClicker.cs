using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuTogglesClicker : MonoBehaviour
{
    [SerializeField]
    private Image buttonBack;
    [SerializeField]
    private TextMeshProUGUI textMainMenu;
    [SerializeField]
    private TextMeshProUGUI buttonSelectionText;
    [SerializeField]
    private Toggle toggle1;
    [SerializeField]
    private Toggle toggle2;
    [SerializeField]
    private Toggle toggle3;
    private MenuVariants menuVariants;
    [SerializeField]
    private GameObject menuVariantsGo;
    private Button button;
    private string toggleText1;
    private string toggleText2;
    private string toggleText3;
    private string currentToggleText;
    private void Awake()
    {
        menuVariants = menuVariantsGo.GetComponent<MenuVariants>();
    }
    void Start()
    {
        button = buttonBack.GetComponent<Button>();
        button.onClick.AddListener(delegate { ButtonBackClicked(); });
        toggle1.isOn = true;
        toggle2.isOn = false;
        toggle3.isOn = false;
        toggle1.onValueChanged.AddListener(delegate { MenuToggle1Clicked(); });
        toggle2.onValueChanged.AddListener(delegate { MenuToggle2Clicked(); });
        toggle3.onValueChanged.AddListener(delegate { MenuToggle3Clicked(); });
        toggleText1 = toggle1.GetComponentInChildren<TextMeshProUGUI>().text;
        toggleText2 = toggle2.GetComponentInChildren<TextMeshProUGUI>().text;
        toggleText3 = toggle3.GetComponentInChildren<TextMeshProUGUI>().text;
        currentToggleText = toggleText1;
        buttonSelectionText.text = currentToggleText;
    }
    public string GetSetCurrentToggleText
    {
        get
        {
            return currentToggleText;
        }
        set
        {
            currentToggleText = value;
        }
    }
    private void MenuToggle1Clicked()
    {
        if (toggle1.isOn == true)
        {
            toggle2.isOn = false;
            toggle3.isOn = false;
            currentToggleText = toggleText1;
            buttonSelectionText.text = currentToggleText;
        }
    }
    private void MenuToggle2Clicked()
    {
        if (toggle2.isOn == true)
        {
            toggle1.isOn = false;
            toggle3.isOn = false;
            currentToggleText = toggleText2;
            buttonSelectionText.text = currentToggleText;
        }
    }
    private void MenuToggle3Clicked()
    {
        if (toggle3.isOn == true)
        {
            toggle1.isOn = false;
            toggle2.isOn = false;
            currentToggleText = toggleText3;
            buttonSelectionText.text = currentToggleText;
        }
    }
    private void ButtonBackClicked()
    {
        gameObject.SetActive(false);
        buttonBack.gameObject.SetActive(false);
        textMainMenu.text = menuVariants.GetSetMainMenuName;
        menuVariants.GetSetMainMenu.gameObject.SetActive(true);
        buttonSelectionText.gameObject.SetActive(false);
    }
}
