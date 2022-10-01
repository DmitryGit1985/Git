using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletImages : MonoBehaviour
{
    [SerializeField] private Transform allBullet;
    [SerializeField] private Transform simpleBulletImage;
    [SerializeField] private Transform grenadeImage;
    [SerializeField] private Transform tennisBallImage;
    #region Images test
    private Image[] allBulletImages;
    #endregion
    public Transform AllBullet { get => allBullet; }
    public Transform SimpleBulletImage { get => simpleBulletImage; }
    public Transform GrenadeImage { get => grenadeImage; }
    public Transform TennisBallImage { get => tennisBallImage; }
    void Start()
    {
        simpleBulletImage.gameObject.SetActive(true);

        #region Images test
        allBulletImages = new Image[allBullet.childCount];
        foreach (Transform child in allBullet)
        {
            allBulletImages.SetValue(child.GetComponent<Image>(), child.GetSiblingIndex());
        }
        #endregion
    }
}
