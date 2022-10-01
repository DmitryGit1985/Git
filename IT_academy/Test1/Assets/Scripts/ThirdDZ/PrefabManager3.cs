using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabManager3 : MonoBehaviour
{
    private GameObject[] ships;
    [SerializeField]
    private Button buttonNext;
    [SerializeField]
    private Button buttonBack;
    //[SerializeField]
    private int currentNumber = 0;
    private GameObject[] instantiateShips;
    private GameObject instantiateShipsMiniCamera;
    void Start()
    {
        LoadAssetsResourses("PrefabsThirdDZ", out ships);
        instantiateShips = new GameObject[ships.Length];
        for (int i=0;i< ships.Length; i++)
        {
            instantiateShips[i]=Instantiate(ships[i]);
            instantiateShips[i].transform.position = new Vector3(0, -2, 8);
            instantiateShips[i].transform.rotation = Quaternion.Euler(20, 180, 0);
            instantiateShips[i].SetActive(false);
        }
        instantiateShips[currentNumber].SetActive(true);
        instantiateShipsMiniCamera = Instantiate(ships[currentNumber],new Vector3(1000,0,0),Quaternion.identity);
        buttonNext.onClick.AddListener(delegate { ButtonNextClicked(); });
        buttonBack.onClick.AddListener(delegate { ButtonBackClicked(); });
    }
    private void ButtonNextClicked()
    {
        instantiateShips[currentNumber].SetActive(false);
        currentNumber = currentNumber + 1;
        if(currentNumber>= ships.Length-1)
        {
            currentNumber = 0;
        }
        instantiateShips[currentNumber].SetActive(true);
        Destroy(instantiateShipsMiniCamera);
        instantiateShipsMiniCamera = Instantiate(ships[currentNumber], new Vector3(1000, 0, 0), Quaternion.identity);
    }
    private void ButtonBackClicked()
    {
        instantiateShips[currentNumber].SetActive(false);
        currentNumber = currentNumber - 1;
        if (currentNumber == -1)
        {
            currentNumber = ships.Length-1;
        }
        instantiateShips[currentNumber].SetActive(true);
        Destroy(instantiateShipsMiniCamera);
        instantiateShipsMiniCamera = Instantiate(ships[currentNumber], new Vector3(1000, 0, 0), Quaternion.identity);
    }
    private void LoadAssetsResourses(string path, out GameObject[] prefabs)
    {
        prefabs = Resources.LoadAll<GameObject>(path);
    }
    public GameObject[] GetSetInstantiateShips
    {
        get
        {
            return instantiateShips;
        }
        set
        {
            instantiateShips = value;
        }
    }
    public int GetSetCurrentNumber
    {
        get
        {
            return currentNumber;
        }
        set
        {
            currentNumber = value;
        }
    }
}