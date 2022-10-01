using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuInputClicker : MonoBehaviour
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
    private Button button;
    private void Awake()
    {
        menuVariants = menuVariantsGo.GetComponent<MenuVariants>();
    }
    void Start()
    {
        button = buttonBack.GetComponent<Button>();
        button.onClick.AddListener(delegate { ButtonBackClicked(); });

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
