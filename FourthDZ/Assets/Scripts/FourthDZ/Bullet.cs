using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletBody;
    [SerializeField] private Collider bulletCollider;
    [SerializeField] private Mesh capsule;
    [SerializeField] private Mesh sphere;
    private float exposionRadius = 10f;
    private float exposionPower = 500f;
    private bool iSexplosionDamage = false;
    private bool destroyOnCollisionEnter = false;
    public Rigidbody BulletBody { get => bulletBody; }
    public Collider BulletCollider { get => bulletCollider; }
    public float ExposionRadius { get => exposionRadius; set => exposionRadius = value; }
    public float ExposionPower { get => exposionPower; }
    public bool ISexplosionDamage { get => iSexplosionDamage; set => iSexplosionDamage = value; }
    public bool DestroyOnCollisionEnter { get => destroyOnCollisionEnter; set => destroyOnCollisionEnter = value; }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (destroyOnCollisionEnter == true)
        {
            Destroy(gameObject);
        }
        if (iSexplosionDamage == true)
        {
            ExplosionDamage(transform.position, exposionRadius);
        }
    }
    private void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.attachedRigidbody != null)
            {
                hitCollider.attachedRigidbody.AddExplosionForce(exposionPower, transform.position, radius, 3.0F);
            }
        }
    }
}
