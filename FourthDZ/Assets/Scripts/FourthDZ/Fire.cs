using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private Bullet bulletType;
    [SerializeField] private bool destroyOnCollisionEnter;
    [SerializeField] private float thrustForceBullets=700f;
    [SerializeField] private float thrustForceGrenade = 3f;
    [SerializeField] private float grenadeAngle = 30f;
    [SerializeField] private float exposionRadius=10f;
    [SerializeField] private float dynFriction=0.4f;
    [SerializeField] private float statFriction=0.0f;
    [SerializeField] private float bounciness = 1;
    private Bullet bulletTypeCopy;
    private Robot robot;
    private Camera mainCamera;
    private RaycastHit hit;
    void Start()
    {
        mainCamera = Camera.main;
        robot = GetComponent<Robot>();
    }
    void Update()
    {
        FireOnTarget();
    }
    private void FireOnTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int bulletOffset = 2;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    bulletTypeCopy = Instantiate(bulletType, robot.transform.position + (transform.forward * bulletOffset), robot.transform.rotation);

                    if (robot.CurrentBulletName == BulletTypes.SimpleBullet.ToString())
                    {
                        AddForceSimpleBullet(true);
                    }
                    if (robot.CurrentBulletName == BulletTypes.Grenade.ToString())
                    {
                        AddForceAtAngle();
                    }
                    if (robot.CurrentBulletName == BulletTypes.TennisBall.ToString())
                    {
                        AddForceSimpleBullet(false);
                        bulletTypeCopy.BulletCollider.material.dynamicFriction = dynFriction;
                        bulletTypeCopy.BulletCollider.material.staticFriction = statFriction;
                        bulletTypeCopy.BulletCollider.material.bounciness = bounciness;
                    }
                }
            }     
        }
    }
    private void AddForceSimpleBullet(bool destroyOnCollisionEnter)
    {
        bulletTypeCopy.DestroyOnCollisionEnter = destroyOnCollisionEnter;
        bulletTypeCopy.BulletBody.AddForce((hit.transform.position - bulletTypeCopy.transform.position).normalized * thrustForceBullets);
    }
    private void AddForceAtAngle()
    {
        bulletTypeCopy.DestroyOnCollisionEnter = true;
        bulletTypeCopy.ISexplosionDamage = true;
        bulletTypeCopy.ExposionRadius = exposionRadius;
        float z = Mathf.Cos(grenadeAngle * Mathf.PI / 180) * thrustForceGrenade;
        float y = Mathf.Sin(grenadeAngle * Mathf.PI / 180) * thrustForceGrenade;
        float x = (hit.transform.position - bulletTypeCopy.transform.position).normalized.x * thrustForceGrenade;
        bulletTypeCopy.BulletBody.AddForce(x, y, z, ForceMode.Impulse);
    }

    #region DistanceTarget test
    private void GetTargetDistance(Collider target,out float distanceTarget)
    {
        distanceTarget = Vector3.Distance(transform.position, target.transform.position);
    }
    #endregion
}
