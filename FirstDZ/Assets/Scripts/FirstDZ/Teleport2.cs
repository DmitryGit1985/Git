using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2 : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    [SerializeField]
    private float period= 1.0f;
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Teleport();
        }
    }
    private void Teleport()
    {
        float x = Random.Range(-5, 5);
        float y = Random.Range(-5, 5);
        float z = Random.Range(-5, 5);
        Vector3 newPosition = new Vector3(x, y, z);
        transform.position = newPosition;
    }
}
