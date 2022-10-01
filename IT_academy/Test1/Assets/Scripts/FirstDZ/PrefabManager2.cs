using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class PrefabManager2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;
    private bool cheker = false;
    private GameObject obj1 = null;
    private GameObject obj2 = null;
    void Start()
    {
        string path = Application.dataPath;
        LoadAssetsResourses("PrefabsFitstDZ", out prefabs);
    }
    void Update()
    {
        DestroyAndInstantiate();
    }
    private void DestroyAndInstantiate()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)//Input.GetKeyDown(KeyCode.Space)
        {
            int currentNumber;
            currentNumber = ExtensionMethods.GetRandomSystemRandom(0, prefabs.Length-1);
            currentNumber = Random.Range(0, prefabs.Length);

            if (cheker == false)
            {
                Destroy(obj2);
                obj1 = Instantiate(prefabs[currentNumber]);
                cheker = true; 
            }
            else 
            {
                Destroy(obj1);
                obj2 = Instantiate(prefabs[currentNumber]);
                cheker = false;
            }
        }
    }
    private void LoadAssetsUnityEditor(string path, out GameObject[] prefabs)
    {
        //using UnityEditor не работает в билде.
        string[] GUIDs = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Resources/"+path });
        prefabs = new GameObject[GUIDs.Length];
        for (int i = 0; i <= GUIDs.Length - 1; i++)
        {
            prefabs[i] = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(GUIDs[i]));
        }
    }
    private void LoadAssetsResourses(string path, out GameObject[] prefabs)
    {   
        prefabs = Resources.LoadAll<GameObject>(path);
    }
}