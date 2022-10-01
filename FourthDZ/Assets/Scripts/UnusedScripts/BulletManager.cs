using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private GameObject[] bullets;
    private int indexOfSimpleBullet;
    private int indexOfGrenadeBullet;
    private int indexOfTennisBallBullet;

    void Awake()
    {
        LoadAssetsResourses("PrefabsFourthDZ", out bullets);
        List<GameObject> objects = new List<GameObject>();
        objects.AddRange(bullets);
        indexOfSimpleBullet = objects.FindIndex(gameObject => string.Equals("SimpleBullet", gameObject.name));
        indexOfGrenadeBullet = objects.FindIndex(gameObject => string.Equals("GrenadeBullet", gameObject.name));
        indexOfTennisBallBullet = objects.FindIndex(gameObject => string.Equals("TennisBallBullet", gameObject.name));

    }
    private void LoadAssetsResourses(string path, out GameObject[] prefabs)
    {
        prefabs = Resources.LoadAll<GameObject>(path);
    }
    public GameObject[] Bullets
    {
        get
        {
            return bullets;
        }
        set
        {
            bullets = value;
        }
    }
    public int IndexOfSimpleBullet
    {
        get
        {
            return indexOfSimpleBullet;
        }
        set
        {
            indexOfSimpleBullet = value;
        }
    }
    public int IndexOfGrenadeBullet
    {
        get
        {
            return indexOfGrenadeBullet;
        }
        set
        {
            indexOfGrenadeBullet = value;
        }
    }
    public int IndexOfTennisBallBullet
    {
        get
        {
            return indexOfTennisBallBullet;
        }
        set
        {
            indexOfTennisBallBullet = value;
        }
    }
}
