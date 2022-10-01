using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField]
    private enum ScaleMaster
    {
        scaler1,
        scaler2,
        scaler3,
        scaleReverce
    }
    [SerializeField]
    private Vector3 scale1 = Vector3.one;
    [SerializeField]
    private Vector3 scale2= new Vector3(5, 5, 5);
    [SerializeField]
    private float scalerSpeed=0.5f;
    [SerializeField]
    private ScaleMaster scaleMaster;

    void Update()
    {
        ChangeScaleVariant();
    }
    private void ChangeScaleVariant()
    {
        switch (scaleMaster)
        {
            case ScaleMaster.scaler1:
                if (transform.localScale.x <= scale2.x&& transform.localScale.y <= scale2.y && transform.localScale.z <= scale2.z)
                {
                    transform.localScale += new Vector3(scalerSpeed, scalerSpeed, scalerSpeed) * Time.deltaTime;
                }
                if (transform.localScale.x > scale2.x && transform.localScale.y > scale2.y && transform.localScale.z > scale2.z)
                {
                    transform.localScale = scale2;
                }
                break;
            case ScaleMaster.scaler2:
                transform.localScale = new Vector3(Mathf.Lerp(scale1.x, scale2.x, scalerSpeed * Time.time), Mathf.Lerp(scale1.y, scale2.y, scalerSpeed * Time.time), Mathf.Lerp(scale1.z, scale2.z, scalerSpeed * Time.time));
                break;
            case ScaleMaster.scaler3:
                transform.localScale = Vector3.Lerp(transform.localScale, scale2, scalerSpeed * Time.deltaTime);
                if (System.Math.Abs(Vector3.Distance(transform.localScale, scale2)) < 0.001f)
                {
                    transform.localScale = scale2;
                }
                break;
            case ScaleMaster.scaleReverce:
                transform.localScale = new Vector3(Mathf.PingPong(Time.time, scale2.x - scale1.x) + scale1.x, Mathf.PingPong(Time.time, scale2.y - scale1.y) + scale1.y, Mathf.PingPong(Time.time, scale2.z - scale1.z) + scale1.z);
                break;
        }
    }
}
//transform.localScale = new Vector3(Mathf.Lerp(scale1.x, scale2.x, Time.time), Mathf.Lerp(scale1.y, scale2.y, Time.time), Mathf.Lerp(scale1.z, scale2.z, Time.time));