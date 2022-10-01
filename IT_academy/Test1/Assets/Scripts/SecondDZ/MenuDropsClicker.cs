using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuDropsClicker : MonoBehaviour
{
    [SerializeField]
    private Image buttonBack;
    [SerializeField]
    private TextMeshProUGUI textMainMenu;
    [SerializeField]
    private TextMeshProUGUI buttonSelectionText;
    private MenuVariants menuVariants;
    [SerializeField]
    private GameObject menuVariantsGo;
    private TMP_Dropdown dropdawn;
    private string currentDropsText;
    private Button button;
    private void Awake()
    {
        menuVariants = menuVariantsGo.GetComponent<MenuVariants>();
    }
    void Start()
    {
        button = buttonBack.GetComponent<Button>();
        button.onClick.AddListener(delegate { ButtonBackClicked(); });
        dropdawn = GetComponentInChildren<TMP_Dropdown>();
        dropdawn.onValueChanged.AddListener(delegate { MenuDropsClicked(); });
        currentDropsText = dropdawn.options[dropdawn.value].text;
        buttonSelectionText.text = currentDropsText;
    }
    public string GetSetCurrentDropsText
    {
        get
        {
            return currentDropsText;
        }
        set
        {
            currentDropsText = value;
        }
    }
    private void MenuDropsClicked()
    {
        currentDropsText = dropdawn.options[dropdawn.value].text;
        buttonSelectionText.text = currentDropsText;
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
