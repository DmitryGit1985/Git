using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallBullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody body;
    [SerializeField]
    private float thrust=500f;
    private RaycastHit hit;

    void Start()
    {
        FindEnemy(out hit);
        body.GetComponent<Rigidbody>();
        body.AddForce((hit.transform.position- transform.position).normalized* thrust);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Robot")
        {
            body.AddForce((-1 * transform.position).normalized * thrust / 2);
        }
    }
    private void FindEnemy(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
    }
}
