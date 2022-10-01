using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIClicker : MonoBehaviour
{
    [SerializeField] private Button ButtonRed;
    [SerializeField] private Button ButtonBlue;
    [SerializeField] private Button ButtonYellow;
    [SerializeField] private Button ButtonGreen;
    [SerializeField] private Button ButtonUp;
    [SerializeField] private Button ButtonDown;
    [SerializeField] private Button ButtonFace;
    [SerializeField] private Button ButtonLeft;
    [SerializeField] PrefabManager3 prefabManager3;
    [SerializeField] private Camera miniCamera;
    [SerializeField] private float speed = 0.05f;
    private Vector2 FirstPosition;
    private Camera mainCamera;
    private int currentResolution;
    private void Start()
    {
        ButtonRed.onClick.AddListener(delegate { ButtonChangeColorClicked(Color.red); });
        ButtonBlue.onClick.AddListener(delegate { ButtonChangeColorClicked(Color.blue); });
        ButtonYellow.onClick.AddListener(delegate { ButtonChangeColorClicked(Color.yellow); });
        ButtonGreen.onClick.AddListener(delegate { ButtonChangeColorClicked(Color.green); });
        ButtonUp.onClick.AddListener(delegate { ChangeMiniCameraPosition(1000, 20, 0, 90, 180, 0); });
        ButtonDown.onClick.AddListener(delegate { ChangeMiniCameraPosition(1000, -20, 0, -90, 0, 0); });
        ButtonFace.onClick.AddListener(delegate { ChangeMiniCameraPosition(1000, 0, 20, 0, 180, 0); });
        ButtonLeft.onClick.AddListener(delegate { ChangeMiniCameraPosition(980, 0, 0, 0, 90, 0); });
        mainCamera = Camera.main;
        currentResolution = Screen.width;
    }
    private void Update()
    {
        TouchRotate();
    }
    private void ButtonChangeColorClicked(Color color)
    {
        GameObject gameObject = prefabManager3.InstantiateShips[prefabManager3.CurrentNumber];
        GameObject gameObjectCamera = prefabManager3.InstantiateShipsMiniCamera;
        gameObject.GetComponent<Renderer>().material.color = color;
        gameObjectCamera.GetComponent<Renderer>().material.color = color;
    }
    private void ChangeMiniCameraPosition(float xPos,float yPos, float zPos, float xRot, float yRot, float zRot)
    {
        miniCamera.transform.position = new Vector3(xPos, yPos, zPos);
        miniCamera.transform.rotation = Quaternion.Euler(xRot, yRot, zRot);
    }
    private void TouchRotate()
    {
        //Vector2 MovePosition;
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    FirstPosition = Input.GetTouch(0).position;
                    //Debug.Log(FirstPosition);
                    // Construct a ray from the current touch coordinates
                    Ray ray = mainCamera.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {

                    }
                }
                if (touch.phase == TouchPhase.Moved)
                {
                Vector2 MovePosition = touch.position;
                    var Direction = MovePosition.x - FirstPosition.x;
                    prefabManager3.InstantiateShips[prefabManager3.CurrentNumber].transform.Rotate(0, -1*Direction * Time.deltaTime*speed, 0);
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    prefabManager3.InstantiateShips[prefabManager3.CurrentNumber].transform.rotation = Quaternion.Euler(20,180,0);
                }
            }
    }
}

