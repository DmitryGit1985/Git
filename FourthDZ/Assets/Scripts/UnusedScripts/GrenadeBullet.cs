using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float thrust=7f;
    [SerializeField] private float angle = 30f;
    [SerializeField] private float exposionRadius = 10f;
    [SerializeField] private float exposionPower = 500f;
    RaycastHit hit;
    void Start()
    {
        body.GetComponent<Rigidbody>();
        AddForceAtAngle(thrust, angle);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Robot")
        {
            Destroy(gameObject);
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
    private void AddForceAtAngle(float force,float angle)
    {
        float z = Mathf.Cos(angle * Mathf.PI / 180) * force;//x Grafic coordinate
        float y = Mathf.Sin(angle * Mathf.PI / 180) * force;//y Grafic coordinate
        float x = (hit.transform.position - transform.position).normalized.x * force;
        body.AddForce(0, y, z, ForceMode.Impulse);//x=0
    }
    private void AddForceAtAngle2(float force, float angle)
    {
        float z = Mathf.Cos(angle) * force;
        float y = Mathf.Sin(angle) * force;
        float x = (hit.transform.position - transform.position).normalized.x * force;
        body.AddForce(x, y, z, ForceMode.Impulse);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, exposionRadius);
    }
}
