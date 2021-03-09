using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallCollisionHandler : MonoBehaviour
{
    private Ball _ball;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            _ball.IncreaseScore();
        }

        if (other.TryGetComponent<Barrier>(out Barrier barrier))
        {
            _ball.Die();
        }
    }
}