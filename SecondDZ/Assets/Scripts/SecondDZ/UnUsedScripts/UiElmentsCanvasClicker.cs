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
    [OnChangedCall("onUiElementClickedChange")]
    private GameObject uiElementClicked;
    public GameObject UiElementClicked { get => uiElementClicked; }
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
    private void GetUiElementsClicked()
    {
        clickData.position = Mouse.current.position.ReadValue();
        clickResults.Clear();
        uiRaycaster.Raycast(clickData, clickResults);
        foreach (RaycastResult result in clickResults)
        {
            uiElementClicked = result.gameObject;
        }
    }
    public void onUiElementClickedChange()
    {
        
    }
}
