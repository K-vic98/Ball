using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] Ball _tracingBall;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        transform.position = new Vector3(_tracingBall.transform.position.x + _xOffset, transform.position.y, transform.position.z);
    }
}