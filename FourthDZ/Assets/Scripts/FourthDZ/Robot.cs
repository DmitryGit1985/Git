using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{   
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Rigidbody body;
    private string currentBulletName;
    private BulletStends bulletStends;
    private BulletImages bulletImages;
    public string CurrentBulletName { get => currentBulletName; }
    public BulletStends BulletStends { get => bulletStends = bulletStends ?? FindObjectOfType<BulletStends>(); }
    public BulletImages BulletImages { get => bulletImages = bulletImages ?? FindObjectOfType<BulletImages>(); }
    void Start()
    {
        currentBulletName = BulletTypes.SimpleBullet.ToString();
        body.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal") * rotationSpeed;
        if (sideForce != 0.0f)
        {
            body.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }
        float forwardForce = Input.GetAxis("Vertical") * movementSpeed;
        if (forwardForce != 0.0f)
        {
            body.velocity = body.transform.forward * forwardForce;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        ChangeBulletOnStends(collision, BulletStends.StendSimpleBulletCol, BulletImages.SimpleBulletImage, BulletTypes.SimpleBullet.ToString());
        ChangeBulletOnStends(collision, BulletStends.StendGrenadeCol, BulletImages.GrenadeImage, BulletTypes.Grenade.ToString());
        ChangeBulletOnStends(collision, BulletStends.StendTennisBallCol, BulletImages.TennisBallImage, BulletTypes.TennisBall.ToString());
    }
    private void ChangeBulletOnStends(Collision collision, Collider bulletStend, Transform bulletImage, string bulletName)
    {
        if (collision.collider == bulletStend)
        {
            foreach (Transform child in BulletImages.AllBullet)
            {
                child.gameObject.SetActive(false);
            }
            bulletImage.gameObject.SetActive(true);
            currentBulletName = bulletName;
        }
    }
}
