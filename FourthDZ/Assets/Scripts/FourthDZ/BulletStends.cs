using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStends : MonoBehaviour
{
    [SerializeField] private Collider stendSimpleBulletCol;
    [SerializeField] private Collider stendGrenadeCol;
    [SerializeField] private Collider stendTennisBallCol;
    public Collider StendSimpleBulletCol { get => stendSimpleBulletCol; }
    public Collider StendGrenadeCol { get => stendGrenadeCol; }
    public Collider StendTennisBallCol { get => stendTennisBallCol; }
    private Collider robotCollider;
    private Robot robot;
    public Robot Robot { get => robot = robot ?? FindObjectOfType<Robot>(); }
    private void Start()
    {
        robotCollider = Robot.GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == Robot)
        {
            
        }
    }
}
