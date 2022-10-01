using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuVariants : MonoBehaviour
{
    [SerializeField]
    private Transform mainMenu;
    [SerializeField]
    private Transform[] menuVariants;
    [SerializeField]
    private string mainMenuName = "Main Menu";
    private static string menuButtonsName = "Buttons";
    private static string menuToggleName = "Toggles";
    private static string menuDropsName = "Drops";
    private static string menuInputName = "Input";
    private static string menuScrollViewName = "ScrollView";
    [SerializeField]
    private string[] menuVariantsNames= { menuButtonsName, menuToggleName, menuDropsName, menuInputName, menuScrollViewName };

    public Transform GetSetMainMenu
    {
        get
        {
            return mainMenu;
        }
        set
        {
            mainMenu = value;
        }
    }
    public Transform[] GetSetMenuVariants
    {
        get
        {
            return menuVariants;
        }
        set
        {
            menuVariants = value;
        }
    }

    public string[] GetSetMenuVariantsNames
    {
        get
        {
            return menuVariantsNames;
        }
        set
        {
            menuVariantsNames = value;
        }
    }
    public string GetSetMainMenuName
    {
        get
        {
            return mainMenuName;
        }
        set
        {
            mainMenuName = value;
        }
    }
}
