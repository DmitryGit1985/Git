using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float thrust=500f;
    [SerializeField] private float otherBodyThrust = 100f;
    public Rigidbody Body { get => body; }
    void Start()
    {
        body.GetComponent<Rigidbody>();
        //body.AddForce(transform.forward * thrust);
        //Vector3 heading = hit.transform.position - transform.position;
        //float distance = heading.magnitude;
        //float distance2 = Vector3.Distance(hit.transform.position, transform.position);//distance=distance2
        //Debug.Log(distance2);
        //Vector3 direction = heading / distance;
        //Vector3 direction2 = (hit.transform.position - transform.position).normalized; //direction = direction2
        //body.AddForce((hit.transform.position- transform.position).normalized* thrust);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Robot")
        {
            Destroy(gameObject);
            //Чтобы пуля не сбивала кубики - увеличить массу кубика.
        }
    }
}
