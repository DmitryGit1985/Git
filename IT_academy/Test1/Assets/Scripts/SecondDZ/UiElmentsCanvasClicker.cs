using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UiElmentsCanvasClicker : MonoBehaviour
{
    private GraphicRaycaster uiRaycaster;
    private PointerEventData clickData;
    private List<RaycastResult> clickResults;
    [SerializeField]
    private GameObject UiElementClicked;
    void Start()
    {
        uiRaycaster = GetComponent<GraphicRaycaster>();
        clickData = new PointerEventData(EventSystem.current);
        clickResults = new List<RaycastResult>();
    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GetUiElementsClicked();
        }
    }
    public GameObject GetSetUiElementClicked
    {
        get 
        { 
            return UiElementClicked; 
        }
        set 
        { 
            UiElementClicked = value; 
        }
    }
    private void GetUiElementsClicked()
    {
        clickData.position = Mouse.current.position.ReadValue();
        clickResults.Clear();
        uiRaycaster.Raycast(clickData, clickResults);
        foreach (RaycastResult result in clickResults)
        {
            UiElementClicked = result.gameObject;
        }
    }
}
