using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuVariants : MonoBehaviour
{
    [SerializeField] private Transform mainMenu;
    [SerializeField] private Transform[] menuVariants;
    [SerializeField] private string mainMenuName = "Main Menu";
    private static string menuButtonsName = "Buttons";
    private static string menuTogglesName = "Toggles";
    private static string menuDropsName = "Drops";
    private static string menuInputName = "Input";
    private static string menuScrollViewName = "ScrollView";
    [SerializeField] private string[] menuVariantsNames= { menuButtonsName, menuTogglesName, menuDropsName, menuInputName, menuScrollViewName };
    public Transform MainMenu { get => mainMenu; }
    public Transform[] MenuVariants_ { get => menuVariants; }
    public string[] MenuVariantsNames { get => menuVariantsNames; }
    public string MainMenuName { get => mainMenuName; }

    [System.Serializable] public struct ButtonVariant
    {
        [SerializeField] private string buttonName;
        [SerializeField] private Transform buttonRect;
        public string ButtonName { get => buttonName; }
        public Transform ButtonRect { get => buttonRect; }

        //public override string ToString() => $"{ButtonName} ({ButtonRect})";
    }
    [SerializeField] private ButtonVariant mainMenuButton;
    [SerializeField] private ButtonVariant[] mainMenuButtons;
    public ButtonVariant MainMenuButton { get => mainMenuButton; }
    public ButtonVariant[] MainMenuButtons { get => mainMenuButtons; }


    void Start()
    {
        
    }
}
