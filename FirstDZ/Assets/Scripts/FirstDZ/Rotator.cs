using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private enum Direction
    {
        left,//x=-1
        right,//x=1
        up,//y=1
        down,//y=-1
        back,//z=-1
        forward//z=1
    }
    [SerializeField]
    private int speed=100;
    [SerializeField]
    private Direction directionName;
    private Direction currentDirectionName;
    void Awake()
    {
        currentDirectionName = directionName;
    }
    void FixedUpdate()
    {
        Change(out Vector3 direction);
        transform.Rotate(direction * Time.deltaTime*speed,Space.Self);
    }
    private void Change(out Vector3 direction)
    {
        direction = Vector3.zero;
        switch (directionName)
        {
            case Direction.left:
                direction = Vector3.left;
                break;
            case Direction.right:
                direction = Vector3.right;
                break;
            case Direction.up:
                direction = Vector3.up;
                break;
            case Direction.down:
                direction = Vector3.down;
                break;
            case Direction.back:
                direction = Vector3.back;
                break;
            case Direction.forward:
                direction = Vector3.forward;
                break;
        }
        if (directionName != currentDirectionName)
        {
            transform.rotation = Quaternion.identity;
            currentDirectionName = directionName;
        }
    }
}
/*public float velocityX = 20f;
public float velocityY = 100f;
public float velocityZ = 50f;*/
//transform.Rotate(velocityX * Time.deltaTime, velocityY * Time.deltaTime, velocityZ * Time.deltaTime, Space.Self);
//transform.Rotate(velocityX, velocityY, velocityZ, Space.Self);
//Awake is called first and, unlike Start, will be called even if the script component is disabled